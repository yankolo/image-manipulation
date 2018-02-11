using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation
{
    public class PnmSerializer : IImageSerializer
    {
        public string Serialize(Image i)
        {
            string[] metaDataLines = i.Metadata.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);

            string metadata = "";
            foreach (string line in metaDataLines)
            {
                metadata += "# " + line + System.Environment.NewLine;
            }

            string widthHeight = i.GetLength(1) + " " + i.GetLength(0) + System.Environment.NewLine;

            string maxRange = i.MaxRange + System.Environment.NewLine;

            string pixels = "";

            for (int y = 0; y < i.GetLength(0); y++)
            {
                for (int x = 0; x < i.GetLength(1); x++)
                {
                    pixels += i[x, y].Red + " " + i[x, y].Green + " " + i[x, y].Blue + " ";
                }
            }

            return "P3" + System.Environment.NewLine + metadata + widthHeight + maxRange + pixels;
        }

        public Image Parse(string imageData)
        {
            string[] lines = imageData.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);
            int currentLine = 1;

            string metadata = "";
            for (; currentLine < lines.Length; currentLine++)
            {
                if (lines[currentLine].StartsWith("#"))
                    metadata += lines[currentLine].Substring(2);
                else
                    break;
            }

            string[] widthHeight = lines[currentLine].Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int width;
            int height;
            if (int.TryParse(widthHeight[0].Trim(), out width) == false)
                throw new InvalidDataException();
            if (int.TryParse(widthHeight[1].Trim(), out height) == false)
                throw new InvalidDataException();
            if (width <= 0 || height <= 0)
                throw new InvalidDataException();

            currentLine++;

            int maxRange;
            if (int.TryParse(lines[currentLine].Trim(), out maxRange) == false)
                throw new InvalidDataException();
            if (maxRange <= 0)
                throw new InvalidDataException();

            currentLine++;

            string restOfLines = "";
            for (; currentLine < lines.Length; currentLine++)
                restOfLines += lines[currentLine] + " ";

            string[] numbersInStrings = restOfLines.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[numbersInStrings.Length];
            for (int i = 0; i < numbersInStrings.Length; i++)
            {
                int number;
                if (int.TryParse(numbersInStrings[i], out number) == false)
                    throw new InvalidDataException();

                if (number > maxRange)
                    throw new InvalidDataException();
            }

            List<Pixel> pixels = new List<Pixel>();
            int counter = 0;
            while (counter < numbers.Length)
            {
                int red = 0;
                int green = 0;
                int blue = 0;
                Pixel pixel = null;

                if (counter % 3 == 0)
                    red = numbers[counter];
                else if ((counter - 1) % 3 == 0)
                    green = numbers[counter];
                else if ((counter - 2) % 3 == 0)
                {
                    blue = numbers[counter];
                    pixel = new Pixel(red, green, blue);
                    pixels.Add(pixel);
                }

                counter++;
            }

            Pixel[,] image = new Pixel[height, width];
            int index = 0;
            for (int row = 0; row < height; row++)
                for (int column = 0; column < width; column++)
                {
                    index = row * width + column;
                    if (index >= pixels.Count)
                        throw new InvalidDataException();
                    image[row, column] = pixels[row * width + column];
                }
            if (pixels.Count - 1 != index)
                throw new InvalidDataException();

            return new Image(metadata, maxRange, image);
        }
    }
}
