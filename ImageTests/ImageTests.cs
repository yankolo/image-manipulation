using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageManipulation;

namespace ImageTests
{
    [TestClass]
    public class ImageTests
    {
        [TestMethod]
        public void ConstructorImage_PassValidArguments_True()
        {
            string metadata = "Creating a valid Image Object";
            int maxRange = 230;
            Pixel[,] p = new Pixel[3, 3];
            p[0, 0] = new Pixel(220);
            p[0, 1] = new Pixel(221);
            p[0, 2] = new Pixel(222);
            p[1, 0] = new Pixel(223);
            p[1, 1] = new Pixel(224);
            p[1, 2] = new Pixel(225);
            p[2, 0] = new Pixel(226);
            p[2, 1] = new Pixel(227);
            p[2, 2] = new Pixel(228);
            Image img = new Image(metadata, maxRange, p);
            
        }
        [TestMethod]
        public void ConstructorImage_PassInvalidArgumentForMaxRange_ExceptionThrown()
        {
            string metadata = "Creating a invalid Image Object";
            int maxRange = -20;
            Pixel[,] p = new Pixel[3, 3];
            p[0, 0] = new Pixel(220);
            p[0, 1] = new Pixel(221);
            p[0, 2] = new Pixel(222);
            p[1, 0] = new Pixel(223);
            p[1, 1] = new Pixel(224);
            p[1, 2] = new Pixel(225);
            p[2, 0] = new Pixel(226);
            p[2, 1] = new Pixel(227);
            p[2, 2] = new Pixel(228);

            try
            {
                Image img = new Image(metadata, maxRange, p);
                Assert.Fail();
            }
            catch
            {

            }
        }
        [TestMethod]
        public void ToGrey_IdenticalGreyValues_True()
        {
            string metadata = "Creating a valid Image Object";
            int maxRange = 240;
            Pixel[,] p = new Pixel[3, 3];
            p[0, 0] = new Pixel(220, 221, 222);
            p[0, 1] = new Pixel(221, 222, 223);
            p[0, 2] = new Pixel(222, 223, 224);
            p[1, 0] = new Pixel(223, 224, 225);
            p[1, 1] = new Pixel(224, 225, 226);
            p[1, 2] = new Pixel(225, 226, 227);
            p[2, 0] = new Pixel(226, 227, 228);
            p[2, 1] = new Pixel(227, 228, 229);
            p[2, 2] = new Pixel(228, 229, 230);

            Image img = new Image(metadata, maxRange, p);

            Pixel[,] expectedPixels = new Pixel[3, 3];
            expectedPixels[0, 0] = new Pixel(221);
            expectedPixels[0, 1] = new Pixel(222);
            expectedPixels[0, 2] = new Pixel(223);
            expectedPixels[1, 0] = new Pixel(224);
            expectedPixels[1, 1] = new Pixel(225);
            expectedPixels[1, 2] = new Pixel(226);
            expectedPixels[2, 0] = new Pixel(227);
            expectedPixels[2, 1] = new Pixel(228);
            expectedPixels[2, 2] = new Pixel(229);

            Image expectedImage = new Image(metadata, maxRange, expectedPixels);

            img.ToGrey();

            Assert.AreEqual(expectedImage, img);
        }

        [TestMethod]
        public void Flip_FlipHorizontalSuccessful_True()
        {
            string metadata = "Creating a valid Image Object";
            int maxRange = 240;
            Pixel[,] p = new Pixel[3, 3];
            p[0, 0] = new Pixel(220, 221, 222);
            p[0, 1] = new Pixel(221, 222, 223);
            p[0, 2] = new Pixel(222, 223, 224);
            p[1, 0] = new Pixel(223, 224, 225);
            p[1, 1] = new Pixel(224, 225, 226);
            p[1, 2] = new Pixel(225, 226, 227);
            p[2, 0] = new Pixel(226, 227, 228);
            p[2, 1] = new Pixel(227, 228, 229);
            p[2, 2] = new Pixel(228, 229, 228);

            Image img = new Image(metadata, maxRange, p);
            img.Flip(true);


            Pixel[,] p2 = new Pixel[3, 3];
            p2[2, 0] = new Pixel(220, 221, 222);
            p2[2, 1] = new Pixel(221, 222, 223);
            p2[2, 2] = new Pixel(222, 223, 224);
            p2[1, 0] = new Pixel(223, 224, 225);
            p2[1, 1] = new Pixel(224, 225, 226);
            p2[1, 2] = new Pixel(225, 226, 227);
            p2[0, 0] = new Pixel(226, 227, 228);
            p2[0, 1] = new Pixel(227, 228, 229);
            p2[0, 2] = new Pixel(228, 229, 228);

            Image img2 = new Image(metadata, maxRange, p2);

            Assert.AreEqual(img2, img);
        }

        [TestMethod]
        public void Flip_FlipVerticalSuccessful_True()
        {
            string metadata = "Creating a valid Image Object";
            int maxRange = 240;
            Pixel[,] p = new Pixel[3, 3];
            p[0, 0] = new Pixel(220, 221, 222);
            p[0, 1] = new Pixel(221, 222, 223);
            p[0, 2] = new Pixel(222, 223, 224);
            p[1, 0] = new Pixel(223, 224, 225);
            p[1, 1] = new Pixel(224, 225, 226);
            p[1, 2] = new Pixel(225, 226, 227);
            p[2, 0] = new Pixel(226, 227, 228);
            p[2, 1] = new Pixel(227, 228, 229);
            p[2, 2] = new Pixel(228, 229, 228);

            Image img = new Image(metadata, maxRange, p);
            img.Flip(false);


            Pixel[,] p2 = new Pixel[3, 3];

            p2[0, 2] = new Pixel(220, 221, 222);
            p2[0, 1] = new Pixel(221, 222, 223);
            p2[0, 0] = new Pixel(222, 223, 224);
            p2[1, 2] = new Pixel(223, 224, 225);
            p2[1, 1] = new Pixel(224, 225, 226);
            p2[1, 0] = new Pixel(225, 226, 227);
            p2[2, 2] = new Pixel(226, 227, 228);
            p2[2, 1] = new Pixel(227, 228, 229);
            p2[2, 0] = new Pixel(228, 229, 228);

            Image img2 = new Image(metadata, maxRange, p2);

            Assert.AreEqual(img2, img);
        }
        [TestMethod]
        public void Crop_PassInvalidArgumentsForStartX_False()
        {
            string metadata = "Creating a valid Image Object";
            int maxRange = 240;
            Pixel[,] p = new Pixel[3, 3];
            p[0, 0] = new Pixel(220, 221, 222);
            p[0, 1] = new Pixel(221, 222, 223);
            p[0, 2] = new Pixel(222, 223, 224);
            p[1, 0] = new Pixel(223, 224, 225);
            p[1, 1] = new Pixel(224, 225, 226);
            p[1, 2] = new Pixel(225, 226, 227);
            p[2, 0] = new Pixel(226, 227, 228);
            p[2, 1] = new Pixel(227, 228, 229);
            p[2, 2] = new Pixel(228, 229, 228);

            Image img = new Image(metadata, maxRange, p);
                
            Assert.ThrowsException<ArgumentException>(() => img.Crop(-2, 0, 0, 0));

        }
        [TestMethod]
        public void Crop_PassInvalidArgumentsForStartY_False()
        {
            string metadata = "Creating a valid Image Object";
            int maxRange = 240;
            Pixel[,] p = new Pixel[3, 3];
            p[0, 0] = new Pixel(220, 221, 222);
            p[0, 1] = new Pixel(221, 222, 223);
            p[0, 2] = new Pixel(222, 223, 224);
            p[1, 0] = new Pixel(223, 224, 225);
            p[1, 1] = new Pixel(224, 225, 226);
            p[1, 2] = new Pixel(225, 226, 227);
            p[2, 0] = new Pixel(226, 227, 228);
            p[2, 1] = new Pixel(227, 228, 229);
            p[2, 2] = new Pixel(228, 229, 228);

            Image img = new Image(metadata, maxRange, p);
                
            Assert.ThrowsException<ArgumentException>(() => img.Crop(0, -2, 0, 0));

        }
        [TestMethod]
        public void Crop_PassInvalidArgumentsForEndX_False()
        {
            string metadata = "Creating a valid Image Object";
            int maxRange = 240;
            Pixel[,] p = new Pixel[3, 3];
            p[0, 0] = new Pixel(220, 221, 222);
            p[0, 1] = new Pixel(221, 222, 223);
            p[0, 2] = new Pixel(222, 223, 224);
            p[1, 0] = new Pixel(223, 224, 225);
            p[1, 1] = new Pixel(224, 225, 226);
            p[1, 2] = new Pixel(225, 226, 227);
            p[2, 0] = new Pixel(226, 227, 228);
            p[2, 1] = new Pixel(227, 228, 229);
            p[2, 2] = new Pixel(228, 229, 228);

            Image img = new Image(metadata, maxRange, p);
            Assert.ThrowsException<ArgumentException>(() => img.Crop(0, 0, -2, 0));


        }
        [TestMethod]
        public void Crop_PassInvalidArgumentsForEndY_False()
        {
            string metadata = "Creating a valid Image Object";
            int maxRange = 240;
            Pixel[,] p = new Pixel[3, 3];
            p[0, 0] = new Pixel(220, 221, 222);
            p[0, 1] = new Pixel(221, 222, 223);
            p[0, 2] = new Pixel(222, 223, 224);
            p[1, 0] = new Pixel(223, 224, 225);
            p[1, 1] = new Pixel(224, 225, 226);
            p[1, 2] = new Pixel(225, 226, 227);
            p[2, 0] = new Pixel(226, 227, 228);
            p[2, 1] = new Pixel(227, 228, 229);
            p[2, 2] = new Pixel(228, 229, 228);

            Image img = new Image(metadata, maxRange, p);
           
            Assert.ThrowsException<ArgumentException>(() => img.Crop(0, 0, 0, -2));
        }
        [TestMethod]
        public void Crop_PassValidArguments_True()
        {
            string metadata = "Creating a valid Image Object";
            int maxRange = 240;
            Pixel[,] p = new Pixel[3, 3];
            p[0, 0] = new Pixel(220, 221, 222);
            p[0, 1] = new Pixel(221, 222, 223);
            p[0, 2] = new Pixel(222, 223, 224);
            p[1, 0] = new Pixel(223, 224, 225);
            p[1, 1] = new Pixel(224, 225, 226);
            p[1, 2] = new Pixel(225, 226, 227);
            p[2, 0] = new Pixel(226, 227, 228);
            p[2, 1] = new Pixel(227, 228, 229);
            p[2, 2] = new Pixel(228, 229, 228);

            Image img = new Image(metadata, maxRange, p);

            Pixel[,] p2 = new Pixel[2, 2];
            p2[0, 0] = new Pixel(220, 221, 222);
            p2[0, 1] = new Pixel(221, 222, 223);
            p2[1, 0] = new Pixel(223, 224, 225);
            p2[1, 1] = new Pixel(224, 225, 226);

            img.Crop(0, 0, 2, 2);

            Image img2 = new Image(metadata, maxRange, p2);

            Assert.AreEqual(img2, img);
        }
        [TestMethod]
        public void GetLength_PassInvalidArgument_False()
        {
            string metadata = "Creating a valid Image Object";
            int maxRange = 240;
            Pixel[,] p = new Pixel[3, 3];
            p[0, 0] = new Pixel(220, 221, 222);
            p[0, 1] = new Pixel(221, 222, 223);
            p[0, 2] = new Pixel(222, 223, 224);
            p[1, 0] = new Pixel(223, 224, 225);
            p[1, 1] = new Pixel(224, 225, 226);
            p[1, 2] = new Pixel(225, 226, 227);
            p[2, 0] = new Pixel(226, 227, 228);
            p[2, 1] = new Pixel(227, 228, 229);
            p[2, 2] = new Pixel(228, 229, 228);

            Image img = new Image(metadata, maxRange, p);
            Assert.ThrowsException<IndexOutOfRangeException>(() => img.GetLength(2));
        }
        [TestMethod]
        public void GetLength_PassValidArgument_True()
        {
            string metadata = "Creating a valid Image Object";
            int maxRange = 240;
            Pixel[,] p = new Pixel[3, 3];
            p[0, 0] = new Pixel(220, 221, 222);
            p[0, 1] = new Pixel(221, 222, 223);
            p[0, 2] = new Pixel(222, 223, 224);
            p[1, 0] = new Pixel(223, 224, 225);
            p[1, 1] = new Pixel(224, 225, 226);
            p[1, 2] = new Pixel(225, 226, 227);
            p[2, 0] = new Pixel(226, 227, 228);
            p[2, 1] = new Pixel(227, 228, 229);
            p[2, 2] = new Pixel(228, 229, 228);

            Image img = new Image(metadata, maxRange, p);
            int expectedLength1 = 3;

            int i = img.GetLength(1);

            Assert.AreEqual(expectedLength1, i);
        }

        [TestMethod]
        public void Equals_EvaluateTwoEqualObjects_True()
        {
            string metadata = "Creating a valid Image Object";
            int maxRange = 240;
            Pixel[,] p = new Pixel[3, 3];
            p[0, 0] = new Pixel(220, 221, 222);
            p[0, 1] = new Pixel(221, 222, 223);
            p[0, 2] = new Pixel(222, 223, 224);
            p[1, 0] = new Pixel(223, 224, 225);
            p[1, 1] = new Pixel(224, 225, 226);
            p[1, 2] = new Pixel(225, 226, 227);
            p[2, 0] = new Pixel(226, 227, 228);
            p[2, 1] = new Pixel(227, 228, 229);
            p[2, 2] = new Pixel(228, 229, 228);

            Image img = new Image(metadata, maxRange, p);

            string metadata2 = "Creating a valid Image Object";
            int maxRange2 = 240;
            Pixel[,] p2 = new Pixel[3, 3];
            p2[0, 0] = new Pixel(220, 221, 222);
            p2[0, 1] = new Pixel(221, 222, 223);
            p2[0, 2] = new Pixel(222, 223, 224);
            p2[1, 0] = new Pixel(223, 224, 225);
            p2[1, 1] = new Pixel(224, 225, 226);
            p2[1, 2] = new Pixel(225, 226, 227);
            p2[2, 0] = new Pixel(226, 227, 228);
            p2[2, 1] = new Pixel(227, 228, 229);
            p2[2, 2] = new Pixel(228, 229, 228);

            Image img2 = new Image(metadata2, maxRange2, p2);

            bool equalsResult = img.Equals(img2);

            Assert.IsTrue(equalsResult);
        }
        [TestMethod]
        public void Equals_EvaluateTwoUnequalObjects_False()
        {
            string metadata = "Creating a valid Image Object";
            int maxRange = 240;
            Pixel[,] p = new Pixel[3, 3];
            p[0, 0] = new Pixel(220, 221, 222);
            p[0, 1] = new Pixel(221, 222, 223);
            p[0, 2] = new Pixel(222, 223, 224);
            p[1, 0] = new Pixel(223, 224, 225);
            p[1, 1] = new Pixel(224, 225, 226);
            p[1, 2] = new Pixel(225, 226, 227);
            p[2, 0] = new Pixel(226, 227, 228);
            p[2, 1] = new Pixel(227, 228, 229);
            p[2, 2] = new Pixel(228, 229, 228);

            Image img = new Image(metadata, maxRange, p);

            string metadata2 = "Creating a valid Image Object";
            int maxRange2 = 240;
            Pixel[,] p2 = new Pixel[3, 3];
            p2[0, 0] = new Pixel(220, 222, 222);
            p2[0, 1] = new Pixel(221, 222, 223);
            p2[0, 2] = new Pixel(222, 223, 224);
            p2[1, 0] = new Pixel(223, 224, 225);
            p2[1, 1] = new Pixel(224, 225, 226);
            p2[1, 2] = new Pixel(225, 226, 227);
            p2[2, 0] = new Pixel(226, 227, 228);
            p2[2, 1] = new Pixel(227, 228, 229);
            p2[2, 2] = new Pixel(228, 229, 228);

            Image img2 = new Image(metadata2, maxRange2, p2);

            bool equalsResult = img.Equals(img2);

            Assert.IsFalse(equalsResult);
        }
        [TestMethod]
        public void Equals_ParamaterIsNull_False()
        {
            string metadata = "Creating a valid Image Object";
            int maxRange = 240;
            Pixel[,] p = new Pixel[3, 3];
            p[0, 0] = new Pixel(220, 221, 222);
            p[0, 1] = new Pixel(221, 222, 223);
            p[0, 2] = new Pixel(222, 223, 224);
            p[1, 0] = new Pixel(223, 224, 225);
            p[1, 1] = new Pixel(224, 225, 226);
            p[1, 2] = new Pixel(225, 226, 227);
            p[2, 0] = new Pixel(226, 227, 228);
            p[2, 1] = new Pixel(227, 228, 229);
            p[2, 2] = new Pixel(228, 229, 228);

            Image img = new Image(metadata, maxRange, p);

            Image img2 = null;

            bool equalsResult = img.Equals(img2);

            Assert.IsFalse(equalsResult);
        }
        [TestMethod]
        public void Equals_ParametersIsNotImage_False()
        {
            string metadata = "Creating a valid Image Object";
            int maxRange = 240;
            Pixel[,] p = new Pixel[3, 3];
            p[0, 0] = new Pixel(220, 221, 222);
            p[0, 1] = new Pixel(221, 222, 223);
            p[0, 2] = new Pixel(222, 223, 224);
            p[1, 0] = new Pixel(223, 224, 225);
            p[1, 1] = new Pixel(224, 225, 226);
            p[1, 2] = new Pixel(225, 226, 227);
            p[2, 0] = new Pixel(226, 227, 228);
            p[2, 1] = new Pixel(227, 228, 229);
            p[2, 2] = new Pixel(228, 229, 228);

            Image img = new Image(metadata, maxRange, p);

            Object img2 = new object();

            bool equalsResult = img.Equals(img2);

            Assert.IsFalse(equalsResult);
        }
        [TestMethod]
        public void Equals_MaxRangeIsNotTheSame_False()
        {
            string metadata = "Creating a valid Image Object";
            int maxRange = 240;
            Pixel[,] p = new Pixel[3, 3];
            p[0, 0] = new Pixel(220, 221, 222);
            p[0, 1] = new Pixel(221, 222, 223);
            p[0, 2] = new Pixel(222, 223, 224);
            p[1, 0] = new Pixel(223, 224, 225);
            p[1, 1] = new Pixel(224, 225, 226);
            p[1, 2] = new Pixel(225, 226, 227);
            p[2, 0] = new Pixel(226, 227, 228);
            p[2, 1] = new Pixel(227, 228, 229);
            p[2, 2] = new Pixel(228, 229, 228);

            Image img = new Image(metadata, maxRange, p);

            string metadata2 = "Creating a valid Image Object";
            int maxRange2 = 255;
            Pixel[,] p2 = new Pixel[3, 3];
            p2[0, 0] = new Pixel(220, 221, 222);
            p2[0, 1] = new Pixel(221, 222, 223);
            p2[0, 2] = new Pixel(222, 223, 224);
            p2[1, 0] = new Pixel(223, 224, 225);
            p2[1, 1] = new Pixel(224, 225, 226);
            p2[1, 2] = new Pixel(225, 226, 227);
            p2[2, 0] = new Pixel(226, 227, 228);
            p2[2, 1] = new Pixel(227, 228, 229);
            p2[2, 2] = new Pixel(228, 229, 228);

            Image img2 = new Image(metadata2, maxRange2, p2);

            bool equalsResult = img.Equals(img2);

            Assert.IsFalse(equalsResult);
        }
    }
}
