using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ImageManipulation
{
    public class ImageUtilities
    {
        /// <summary>
        /// Looks for all the files ending with .pgm or .pnm (Not recursive) inside a directory
        /// and creates an Image[] from those files
        /// </summary>
        /// <param name="directory">The directory path from which to load imagess</param>
        /// <returns></returns>
        public static Image[] LoadFolder(string directory)
        {
            string[] files = Directory.GetFiles(directory);

            List<Image> images = new List<Image>();

            PgmSerializer pgm = new PgmSerializer();
            PnmSerializer pnm = new PnmSerializer();

            foreach (string file in files)
            {
                if (file.EndsWith(".pnm") || file.EndsWith(".pgm"))
                {
                    try
                    {
                        using (StreamReader reader = new StreamReader(file))
                        {
                            string fileText = reader.ReadToEnd();
                            if (file.EndsWith(".pnm"))
                                images.Add(pnm.Parse(fileText));
                            else
                                images.Add(pgm.Parse(fileText));
                        }
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Error reading from file");
                    }
                    catch (InvalidDataException)
                    {
                        Console.WriteLine("Invalid image data");
                    }
                }
            }

            return images.ToArray();
        }

        /// <summary>
        /// Exports every Image object inside the Image[] to a directory using a specific format (pnm or pgm)
        /// </summary>
        /// <param name="directory">The directory to export the images</param>
        /// <param name="images">The images to export</param>
        /// <param name="format">The format used to export the images (either pnm or pgm)</param>
        public static void SaveFolder(string directory, Image[] images, string format)
        {
            PgmSerializer pgm = new PgmSerializer();
            PnmSerializer pnm = new PnmSerializer();
            for (int i = 0; i < images.Length; i++)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(new FileStream(directory + "\\" + i + "." + format, FileMode.Create, FileAccess.Write)))
                    {
                        if (format == "pgm")
                            writer.Write(pgm.Serialize(images[i]));
                        else
                            writer.Write(pnm.Serialize(images[i]));
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine("Error writing to file");
                }
            }
        }
    }

}

