using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation
{
    class Image
    {
        private Pixel[,] _data;

        public String Metadata { get; private set; }

        public int MaxRange { get; private set; }

        public Pixel this [int x , int y]
        {
            get
            {
                return _data[x, y];
            }
        }

        public int GetLength(int rank)
        {
            if (rank != 0 || rank != 1)
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
            for (int x = 0; x < data.GetLength(0); x++)
                for (int y = 0; y < data.GetLength(1); y++)
                    _data[x, y] = data[x, y];
        }

        public void ToGrey()
        {
            for (int x = 0; x < _data.GetLength(0); x++)
                for (int y = 0; y < _data.GetLength(1); y++)
                    _data[x, y] = new Pixel(_data[x, y].Grey());
        }

        public void Flip(bool horizontal)
        {
            if (horizontal)
            {
                for (int y = 0; y < _data.GetLength(0); y++)
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
                for (int x = 0; x < _data.GetLength(1); x++)
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
            if (startX > endX || startY > endY || startX < 0 || startY < 0 || endX > _data.GetLength(2) || endY > _data.GetLength(1))
                throw new ArgumentException("Invalid crop coordinates");

            Pixel[,] croppedImage = new Pixel[(endY - startY), (endX - startX)];

            for (int y = startY; y < endY; y++)
                for (int x = startX; x < endX; x++)
                {
                    croppedImage[y, x] = _data[y,x];
                }
            _data = croppedImage;
        }
    }
}
