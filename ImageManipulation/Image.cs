using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation
{
    public class Image
    {
        private Pixel[,] _data;

        public String Metadata { get; private set; }

        public int MaxRange { get; private set; }

        public Pixel this [int y , int x]
        {
            get
            {
                return _data[y, x];
            }
        }
        /// <summary>
        /// Returns the length of the 2D pixel array
        /// </summary>
        /// <param name="rank"></param>
        /// <returns>Returns the length of the dimension wished</returns>
        public int GetLength(int rank)
        {
            if (rank != 0 && rank != 1)
                throw new IndexOutOfRangeException("You can only use ranks of either 0 or 1");

            if (rank == 0)
                return _data.GetLength(0);
            else
                return _data.GetLength(1);
        }
        /// <summary>
        /// Constructor for the Image class, creates a image object
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="maxRange"></param>
        /// <param name="data"></param>
        public Image(string metadata, int maxRange, Pixel[,] data)
        {
            if (maxRange < 0)
                throw new ArgumentException("Max Range cannot be negative");

            Metadata = metadata;
            MaxRange = maxRange;

            _data = new Pixel[data.GetLength(0), data.GetLength(1)];
            for (int y = 0; y < data.GetLength(0); y++)
            {
                for (int x = 0; x < data.GetLength(1); x++)
                {
                    if (data[y, x].Green > MaxRange|| data[y,x].Blue > MaxRange || data[y,x].Red > MaxRange)
                    {
                        throw new ArgumentException("Pixel Values cannot be bigger than the MaxRange");
                    }
                    else
                    {
                        _data[y, x] = data[y, x];

                    }
                }

            }
        }
        /// <summary>
        /// Turns the Image to grey.
        /// Turns each pixel to grey.
        /// </summary>
        public void ToGrey()
        {
            for (int y = 0; y < _data.GetLength(0); y++)
                for (int x = 0; x < _data.GetLength(1); x++)
                    _data[y, x] = new Pixel(_data[y, x].Grey());
        }
        /// <summary>
        /// Flips the Image object depending on a boolean value.
        /// If boolean value is true, the image will flip horizontally.
        /// If boolean value is false, the image will flip vertically.
        /// </summary>
        /// <param name="horizontal"></param>
        public void Flip(bool horizontal)
        {
            if (horizontal)
            {
                for (int y = 0; y < _data.GetLength(0)/2; y++)
                {
                    Pixel[] temp = new Pixel[_data.GetLength(1)];

                    for (int x = 0; x < _data.GetLength(1); x++)
                    {
                        temp[x] = _data[y, x];
                        _data[y, x] = _data[_data.GetLength(0) - (1 + y), x];
                        _data[_data.GetLength(0) - (1 + y), x] = temp[x];
                    }
                }
            }
            else
            {
                for (int x = 0; x < _data.GetLength(1)/2; x++)
                {
                    Pixel[] temp = new Pixel[_data.GetLength(0)];

                    for (int y = 0; y < _data.GetLength(0); y++)
                    {
                        temp[y] = _data[y, x];
                        _data[y, x] = _data[y, _data.GetLength(1) - (1 + x)];
                        _data[y, _data.GetLength(1) - (1 + x)] = temp[y];
                    }
                }
            }
        }
        /// <summary>
        /// This method crops the Image depending on 4 coordinates.
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="endX"></param>
        /// <param name="endY"></param>
        public void Crop(int startX, int startY , int endX, int endY)
        {
            if (startX > endX || startY > endY || startX < 0 || startY < 0 || endX > _data.GetLength(1) || endY > _data.GetLength(0))
                throw new ArgumentException("Invalid coordinates: Values must be postive, startX and startY must be bigger than endX and endY, endX and endY cannot" +
                    " be bigger than the size of the pixel array");

            Pixel[,] croppedImage = new Pixel[(endY - startY), (endX - startX)];

            for (int y = startY; y < endY; y++)
                for (int x = startX; x < endX; x++)
                {
                    croppedImage[y, x] = _data[y,x];
                }
            _data = croppedImage;
        }
        /// <summary>
        /// Evaluates if two objects are equal depending on their maxRange and that each of
        /// their pixels are equal.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Returns true or false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var img = obj as Image;

            if (img == null)
            {
                return false;
            }
            else
            {
                if (img.MaxRange != MaxRange)
                    return false;

                for(int y = 0; y < _data.GetLength(0); y++)
                {
                    for(int x = 0; x < _data.GetLength(1); x++)
                    {
                        if (!(_data[y, x].Equals(img[y, x])))
                            return false;
                            
                    } 
                }
                return true;
            }
        }
    }
}
