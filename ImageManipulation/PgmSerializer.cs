using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation
{
    public class PgmSerializer : IImageSerializer
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
                    pixels += i[x, y].Red + " ";
                }
            }

            return "P2" + System.Environment.NewLine + metadata + widthHeight + maxRange + pixels;
        }

        public Image Parse(string imageData)
        {
            // Getting information from string

            string[] lines = imageData.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);

            int currentLine = 1;

            string metadata = "";
            while (currentLine < lines.Length)
            {
                if (lines[currentLine].StartsWith("#"))
                    metadata += lines[currentLine].Substring(2) + " ";
                else
                    break;

                currentLine++;
            }

            string[] widthHeight = lines[currentLine].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string widthInString = widthHeight[0].Trim();
            string heightInString = widthHeight[1].Trim();

            currentLine++;

            string maxRangeInString = lines[currentLine].Trim();

            currentLine++;

            List<string> numbersInStrings = new List<string>();
            while (currentLine < lines.Length)
            {
                string[] numbersOnLine = lines[currentLine].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string number in numbersOnLine)
                    numbersInStrings.Add(number);

                currentLine++;
            }

            // Validating the information and parsing it into the right type

            int width;
            int height;
            if (int.TryParse(widthInString, out width) == false)
                throw new InvalidDataException();
            if (int.TryParse(heightInString, out height) == false)
                throw new InvalidDataException();
            if (width <= 0 || height <= 0)
                throw new InvalidDataException();

            int maxRange;
            if (int.TryParse(maxRangeInString, out maxRange) == false)
                throw new InvalidDataException();
            if (maxRange <= 0)
                throw new InvalidDataException();

            if (numbersInStrings.Count != height * width)
                throw new InvalidDataException();

            int[] numbers = new int[numbersInStrings.Count];
            for (int i = 0; i < numbersInStrings.Count; i++)
            {
                int number;
                if (int.TryParse(numbersInStrings[i], out number) == false)
                    throw new InvalidDataException();
                if (number > maxRange)
                    throw new InvalidDataException();

                numbers[i] = number;
            }

            // Creating image object

            List<Pixel> pixels = new List<Pixel>();
            for (int i = 0; i < numbers.Length; i++)
            {
                int colour = numbers[i];
                Pixel pixel = new Pixel(colour);
                pixels.Add(pixel);
            }

            Pixel[,] image = new Pixel[height, width];
            for (int row = 0; row < height; row++)
                for (int column = 0; column < width; column++)
                    image[row, column] = pixels[row * width + column];

            return new Image(metadata, maxRange, image);
        }
    }
}
