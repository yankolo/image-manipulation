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

            try
            {
                Image img = new Image(metadata, maxRange, p);
            }
            catch
            {
                Assert.Fail();
            }
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
            p[2, 2] = new Pixel(228, 229, 228);

            Image img = new Image(metadata, maxRange, p);
            img.ToGrey();


            for (int x = 0; x < img.GetLength(0); x++)
                for (int y = 0; y < img.GetLength(1); y++)
                    if(!(img[x,y].Equals(new Pixel(p[x,y].Grey()))))
                        Assert.Fail();
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
            for (int x = 0; x < img.GetLength(0); x++)
                for (int y = 0; y < img.GetLength(1); y++)
                    if (!(img[x, y].Equals(img2[x, y])))
                        Assert.Fail();

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

            for (int x = 0; x < img.GetLength(0); x++)
                for (int y = 0; y < img.GetLength(1); y++)
                    if (!(img[x, y].Equals(img2[x, y])))
                        Assert.Fail();


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
            try
            {
                img.Crop(-2, 0, 0, 0);
            }
            catch
            {

            }
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
            try
            {
                img.Crop(0,-2,0,0);
            }
            catch
            {

            }
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
            try
            {
                img.Crop(0, 0, -2, 0);
            }
            catch
            {

            }
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
            try
            {
                img.Crop(0, 0, 0, -2);
            }
            catch
            {

            }
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
            for (int x = 0; x < img.GetLength(0); x++)
                for (int y = 0; y < img.GetLength(1); y++)
                    if (!(img[x, y].Equals(p2[x, y])))
                        Assert.Fail();

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

            try
            {
               int i =  img.GetLength(2);
            }
            catch
            {

            }
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

            try
            {
                int i = img.GetLength(1);
            }
            catch
            {

            }
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

            if (!(img.Equals(img2)))
            {
                Assert.Fail();
            }



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

            if ((img.Equals(img2)))
            {
                Assert.Fail();
            }



        }


    }
}
