using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation
{
    public class Pixel
    {
        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }

        public Pixel(int intensity)
        {
            if (intensity < 0 || intensity > 255)
                throw new ArgumentException("The value entered for the intensity is invalid. Enter rgb value between 0 and 255");
            Red = intensity;
            Green = intensity;
            Blue = intensity;
        }


        public Pixel(int red, int green, int blue)
        {
            Red = ValidateColor(red, "Red");
            Green = ValidateColor(green, "Green");
            Blue = ValidateColor(blue, "Blue");
        }

        public int Grey()
        {
            return (Red + Green + Blue) / 3;
        }

        private int ValidateColor(int color, string colorName)
        {
            if (color < 0 || color > 255)
                throw new ArgumentException("The value for the color " + colorName + " is invalid. Enter rgb value between 0 and 255");
            return color;
        }
    }
}
