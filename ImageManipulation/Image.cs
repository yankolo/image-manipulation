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

        public int GetLength(int rank)
        {
            if (rank != 0 && rank != 1)
                throw new IndexOutOfRangeException("You can only use ranks of either 0 or 1");

            if (rank == 0)
                return _data.GetLength(0);
            else
                return _data.GetLength(1);
        }

        public Image(string metadata, int maxRange, Pixel[,] data)
        {
            if (maxRange < 0)
                throw new ArgumentException("");

            Metadata = metadata;
            MaxRange = maxRange;

            _data = new Pixel[data.GetLength(0), data.GetLength(1)];
            for (int y = 0; y < data.GetLength(0); y++)
                for (int x = 0; x < data.GetLength(1); x++)
                    _data[y, x] = data[y, x];
        }

        public void ToGrey()
        {
            for (int y = 0; y < _data.GetLength(0); y++)
                for (int x = 0; x < _data.GetLength(1); x++)
                    _data[y, x] = new Pixel(_data[y, x].Grey());
        }

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

        public void Crop(int startX, int startY , int endX, int endY)
        {
            if (startX > endX || startY > endY || startX < 0 || startY < 0 || endX > _data.GetLength(1) || endY > _data.GetLength(0))
                throw new ArgumentException("Invalid crop coordinates");

            Pixel[,] croppedImage = new Pixel[(endY - startY), (endX - startX)];

            for (int y = startY; y < endY; y++)
                for (int x = startX; x < endX; x++)
                {
                    croppedImage[y, x] = _data[y,x];
                }
            _data = croppedImage;
        }
        public override bool Equals(object obj)
        {
            var img = obj as Image;

            if (img == null)
            {
                return false;
            }
            else
            {
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
