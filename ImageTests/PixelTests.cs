using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageManipulation;

namespace ImageTests
{
    [TestClass]
    public class PixelTests
    {
        [TestMethod]
        public void ConstructorPixel_AllValidElements_True()
        {
            try
            {
                Pixel p = new Pixel(200,200,250);
            }
            catch
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void ConstructorPixel_InvalidElementRed_ExceptionThrown()
        {
            try
            {
                Pixel p = new Pixel(-2, 200, 250);
                Assert.Fail();
            }
            catch
            {
                
            }
        }
        [TestMethod]
        public void ConstructorPixel_InvalidElementGreen_ExceptionThrown()
        {
            try
            {
                Pixel p = new Pixel(200, -2, 250);
                Assert.Fail();
            }
            catch
            {

            }
        }
        [TestMethod]
        public void ConstructorPixel_InvalidElementBlue_ExceptionThrown()
        {
            try
            {
                Pixel p = new Pixel(200, 200, 256);
                Assert.Fail();
            }
            catch
            {

            }
        }

        [TestMethod]
        public void ConstructorPixel_ValidIntensityValue_True()
        {
            try
            {
                Pixel p = new Pixel(200);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ConstructorPixel_InvalidPositiveIntensityValue_ExceptionThrown()
        {
            try
            {
                Pixel p = new Pixel(270);
                Assert.Fail();
            }
            catch
            {
                
            }
        }
        [TestMethod]
        public void ConstructorPixel_InvalidNegativeIntensityValue_ExceptionThrown()
        {
            try
            {
                Pixel p = new Pixel(-20);
                Assert.Fail();
            }
            catch
            {

            }
        }
        [TestMethod]
        public  void Grey_ValidNumbers_True()
        {
            Pixel p = new Pixel(222, 223, 224);
            int greyPixelValue = p.Grey();
            int valueToBeCompared = (222 + 223 + 224) / 3;
            Assert.AreEqual(greyPixelValue, valueToBeCompared);
        }
        [TestMethod]
        public void Grey_ValidNumberButNotEqual_False()
        {
            Pixel pi = new Pixel(222, 223, 224);
            int greyPiValue = pi.Grey();
            Pixel pix = new Pixel(222);
            int greyPixValue = pix.Grey();

            Assert.AreNotEqual(greyPiValue, greyPixValue);
        }


    }
}
