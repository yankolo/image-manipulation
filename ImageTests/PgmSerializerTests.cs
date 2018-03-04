using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageManipulation;
using System.IO;

namespace ImageTests
{
    [TestClass]
    public class PgmSerializerTests
    {
        [TestMethod]
        public void Serialize_ValidImageOneMetadataLine_True()
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
        public void Serialize_ValidImageSeveralMetadataLines_True()
        {
            Pixel[,] pixels = new Pixel[2, 3];
            pixels[0, 0] = new Pixel(255);
            pixels[0, 1] = new Pixel(122);
            pixels[0, 2] = new Pixel(100);
            pixels[1, 0] = new Pixel(155);
            pixels[1, 1] = new Pixel(180);
            pixels[1, 2] = new Pixel(200);
            Image image = new Image("This is a test image" + System.Environment.NewLine + "This is a second line", 255, pixels);
            string stringToCompare = "P2" + System.Environment.NewLine + "# This is a test image" + System.Environment.NewLine + "# This is a second line" + System.Environment.NewLine + "3 2" +
                System.Environment.NewLine + "255" + System.Environment.NewLine + "255 122 100 155 180 200";

            PgmSerializer serializer = new PgmSerializer();
            string imageAsString = serializer.Serialize(image);

            Assert.AreEqual(stringToCompare, imageAsString);
        }

        [TestMethod]
        public void Serialize_ValidImageNoMetadata_True()
        {
            Pixel[,] pixels = new Pixel[2, 3];
            pixels[0, 0] = new Pixel(255);
            pixels[0, 1] = new Pixel(122);
            pixels[0, 2] = new Pixel(100);
            pixels[1, 0] = new Pixel(155);
            pixels[1, 1] = new Pixel(180);
            pixels[1, 2] = new Pixel(200);
            Image image = new Image("", 255, pixels);
            string stringToCompare = "P2" + System.Environment.NewLine + "3 2" +
                System.Environment.NewLine + "255" + System.Environment.NewLine + "255 122 100 155 180 200";

            PgmSerializer serializer = new PgmSerializer();
            string imageAsString = serializer.Serialize(image);

            Assert.AreEqual(stringToCompare, imageAsString);
        }

        [TestMethod]
        public void Parse_ValidImageOneMetadataLine_True()
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
            Assert.AreEqual(imageToCompare.Metadata, image.Metadata);
        }

        [TestMethod]
        public void Parse_ValidImageSeveralMetadataLines_True()
        {
            string stringToParse = "P2" + System.Environment.NewLine + "# This is a test image" + System.Environment.NewLine + "# This is a second line" + System.Environment.NewLine + "3 2" +
                System.Environment.NewLine + "255" + System.Environment.NewLine + "255 122 100 155 180 200";
            Pixel[,] pixels = new Pixel[2, 3];
            pixels[0, 0] = new Pixel(255);
            pixels[0, 1] = new Pixel(122);
            pixels[0, 2] = new Pixel(100);
            pixels[1, 0] = new Pixel(155);
            pixels[1, 1] = new Pixel(180);
            pixels[1, 2] = new Pixel(200);
            Image imageToCompare = new Image("This is a test image" + System.Environment.NewLine + "This is a second line", 255, pixels);

            PgmSerializer serializer = new PgmSerializer();
            Image image = serializer.Parse(stringToParse);

            Assert.AreEqual(imageToCompare, image);
            Assert.AreEqual(imageToCompare.Metadata, image.Metadata);
        }

        [TestMethod]
        public void Parse_ValidImageNoMetadata_True()
        {
            string stringToParse = "P2" + System.Environment.NewLine + "3 2" +
                System.Environment.NewLine + "255" + System.Environment.NewLine + "255 122 100 155 180 200";
            Pixel[,] pixels = new Pixel[2, 3];
            pixels[0, 0] = new Pixel(255);
            pixels[0, 1] = new Pixel(122);
            pixels[0, 2] = new Pixel(100);
            pixels[1, 0] = new Pixel(155);
            pixels[1, 1] = new Pixel(180);
            pixels[1, 2] = new Pixel(200);
            Image imageToCompare = new Image("", 255, pixels);

            PgmSerializer serializer = new PgmSerializer();
            Image image = serializer.Parse(stringToParse);
            
            Assert.AreEqual(imageToCompare, image);
            Assert.AreEqual(imageToCompare.Metadata, image.Metadata);
        }

        [TestMethod]
        public void Parse_WidthNotANumber_InvalidDataException()
        {
            string stringToParse = "P2" + System.Environment.NewLine + "# This is a test image" + System.Environment.NewLine + "three 2" +
                System.Environment.NewLine + "255" + System.Environment.NewLine + "255 122 100 155 180 200";

            PgmSerializer serializer = new PgmSerializer();

            Assert.ThrowsException<InvalidDataException>(() => serializer.Parse(stringToParse));
        }

        [TestMethod]
        public void Parse_HeightNotANumber_InvalidDataException()
        {
            string stringToParse = "P2" + System.Environment.NewLine + "# This is a test image" + System.Environment.NewLine + "3 two" +
                System.Environment.NewLine + "255" + System.Environment.NewLine + "255 122 100 155 180 200";

            PgmSerializer serializer = new PgmSerializer();

            Assert.ThrowsException<InvalidDataException>(() => serializer.Parse(stringToParse));
        }

        [TestMethod]
        public void Parse_WidthLessThan0_InvalidDataException()
        {
            string stringToParse = "P2" + System.Environment.NewLine + "# This is a test image" + System.Environment.NewLine + "-3 2" +
                System.Environment.NewLine + "255" + System.Environment.NewLine + "255 122 100 155 180 200";

            PgmSerializer serializer = new PgmSerializer();

            Assert.ThrowsException<InvalidDataException>(() => serializer.Parse(stringToParse));
        }
        
        [TestMethod]
        public void Parse_HeightLessThan0_InvalidDataException()
        {
            string stringToParse = "P2" + System.Environment.NewLine + "# This is a test image" + System.Environment.NewLine + "3 -2" +
                System.Environment.NewLine + "255" + System.Environment.NewLine + "255 122 100 155 180 200";

            PgmSerializer serializer = new PgmSerializer();

            Assert.ThrowsException<InvalidDataException>(() => serializer.Parse(stringToParse));
        }

        [TestMethod]
        public void Parse_MaxRangeNotANumber_InvalidDataException()
        {
            string stringToParse = "P2" + System.Environment.NewLine + "# This is a test image" + System.Environment.NewLine + "3 2" +
                System.Environment.NewLine + "two-hundred-and-fifty-five" + System.Environment.NewLine + "255 122 100 155 180 200";

            PgmSerializer serializer = new PgmSerializer();

            Assert.ThrowsException<InvalidDataException>(() => serializer.Parse(stringToParse));
        }

        [TestMethod]
        public void Parse_MaxRangeLessThan0_InvalidDataException()
        {
            string stringToParse = "P2" + System.Environment.NewLine + "# This is a test image" + System.Environment.NewLine + "3 2" +
                System.Environment.NewLine + "-255" + System.Environment.NewLine + "255 122 100 155 180 200";

            PgmSerializer serializer = new PgmSerializer();

            Assert.ThrowsException<InvalidDataException>(() => serializer.Parse(stringToParse));
        }

        [TestMethod]
        public void Parse_InvalidAmountOfNumbers_InvalidDataException()
        {
            string stringToParse = "P2" + System.Environment.NewLine + "# This is a test image" + System.Environment.NewLine + "3 2" +
                System.Environment.NewLine + "255" + System.Environment.NewLine + "255 122 100 155 180 200 200 200";

            PgmSerializer serializer = new PgmSerializer();

            Assert.ThrowsException<InvalidDataException>(() => serializer.Parse(stringToParse));
        }

        [TestMethod]
        public void Parse_PixelNotANumber_InvalidDataException()
        {
            string stringToParse = "P2" + System.Environment.NewLine + "# This is a test image" + System.Environment.NewLine + "3 2" +
                System.Environment.NewLine + "255" + System.Environment.NewLine + "two-hundred-and-fifty-five 122 one-hundred 155 180 200";

            PgmSerializer serializer = new PgmSerializer();

            Assert.ThrowsException<InvalidDataException>(() => serializer.Parse(stringToParse));
        }

        [TestMethod]
        public void Parse_PixelColourGreaterThanMaxRange_InvalidDataException()
        {
            string stringToParse = "P2" + System.Environment.NewLine + "# This is a test image" + System.Environment.NewLine + "3 2" +
                System.Environment.NewLine + "255" + System.Environment.NewLine + "300 122 100 155 180 200";

            PgmSerializer serializer = new PgmSerializer();

            Assert.ThrowsException<InvalidDataException>(() => serializer.Parse(stringToParse));
        }
    }
}
