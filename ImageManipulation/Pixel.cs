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
        /// <summary>
        /// Constructor to create a Pixel object
        /// </summary>
        /// <param name="intensity"></param>
        public Pixel(int intensity)
        {
            if (intensity < 0 || intensity > 255)
                throw new ArgumentException("The value entered for the intensity is invalid. Enter rgb value between 0 and 255");
            Red = intensity;
            Green = intensity;
            Blue = intensity;
        }

        /// <summary>
        /// Constructor to create a Pixel object.
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        public Pixel(int red, int green, int blue)
        {
            Red = ValidateColor(red, "Red");
            Green = ValidateColor(green, "Green");
            Blue = ValidateColor(blue, "Blue");
        }
        /// <summary>
        /// Returns the grey value of a Pixel object, which is the average of the rgb values.
        /// </summary>
        /// <returns></returns>
        public int Grey()
        {
            return (Red + Green + Blue) / 3;
        }
        /// <summary>
        /// Evaluates if two Pixel objects are equal depending on their Red, Blue and Green values.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Returns true or false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var pix = obj as Pixel;
            
            if(pix == null)
            {
                return false;
            }
            else
            {
                if ((Red != pix.Red) || (Green != pix.Green) || (Blue != pix.Blue))
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }

        }

        private int ValidateColor(int color, string colorName)
        {
            if (color < 0 || color > 255)
                throw new ArgumentException("The value for the color " + colorName + " is invalid. Enter rgb value between 0 and 255");
            return color;
        }
    }
}
