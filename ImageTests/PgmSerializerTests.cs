using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageManipulation;

namespace ImageTests
{
    [TestClass]
    public class PgmSerializerTests
    {
        [TestMethod]
        public void Serialize_ValidImage_True()
        {
            Pixel[,] pixels = new Pixel[2, 3];
            pixels[0, 0] = new Pixel(255);
            pixels[0, 1] = new Pixel(122);
            pixels[0, 2] = new Pixel(100);
            pixels[1, 0] = new Pixel(155);
            pixels[1, 1] = new Pixel(180);
            pixels[1, 2] = new Pixel(200);
            Image image = new Image("This is a test image", 255, pixels);
            string stringToCompare = "P2" + System.Environment.NewLine + "# This is a test image" + System.Environment.NewLine + "3 2" +
                System.Environment.NewLine + "255" + System.Environment.NewLine + "255 122 100 155 180 200";

            PgmSerializer serializer = new PgmSerializer();
            string imageAsString = serializer.Serialize(image);

            Assert.AreEqual(stringToCompare, imageAsString);
        }

        [TestMethod]
        public void Parse_ValidImage_True()
        {
            string stringToParse = "P2" + System.Environment.NewLine + "# This is a test image" + System.Environment.NewLine + "3 2" +
                System.Environment.NewLine + "255" + System.Environment.NewLine + "255 122 100 155 180 200";
            Pixel[,] pixels = new Pixel[2, 3];
            pixels[0, 0] = new Pixel(255);
            pixels[0, 1] = new Pixel(122);
            pixels[0, 2] = new Pixel(100);
            pixels[1, 0] = new Pixel(155);
            pixels[1, 1] = new Pixel(180);
            pixels[1, 2] = new Pixel(200);
            Image imageToCompare = new Image("This is a test image", 255, pixels);

            PgmSerializer serializer = new PgmSerializer();
            Image image = serializer.Parse(stringToParse);

            Assert.AreEqual(imageToCompare, image);
        }
    }
}
