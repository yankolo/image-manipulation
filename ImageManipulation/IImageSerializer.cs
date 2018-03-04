using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation
{
    public interface IImageSerializer
    {
        /// <summary>
        /// Converts and Image object to a String
        /// Example of an Image string representation:
        /// 
        /// P3
        /// # Metadata...
        /// 3 2
        /// 255
        /// 255 0 0 0 255 0 0 0 255
        /// 255 255 0 255 255 255 0 0 0
        /// 
        /// </summary>
        /// <param name="i">The Image object to convert</param>
        /// <returns>A String representing the Image object</returns>
        String Serialize(Image i);

        /// <summary>
        /// Converts a String containing image data to an Image object
        /// 
        /// </summary>
        /// <param name="imageData">The String that contains the image data</param>
        /// <returns>An Image object</returns>
        /// <exception cref="InvalidDataException">Thrown when an invalid String is passed</exception>
        Image Parse(String imageData);
    }
}

