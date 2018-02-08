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
                for (int y = 0; y < _data.GetLength(1); y++)
                {
                    Pixel[] temp = new Pixel[_data.GetLength(2)];

                    for (int x = 0; x < _data.GetLength(2); x++)
                    {
                        temp[x] = _data[y, x];
                        _data[y, x] = _data[_data.GetLength(1) - (1 + y), x];
                        _data[_data.GetLength(1) - (1 + y), x] = temp[x];
                    }
                }
            }
            else
            {
                for (int x = 0; x < _data.GetLength(2); x++)
                {
                    Pixel[] temp = new Pixel[_data.GetLength(1)];

                    for (int y = 0; y < _data.GetLength(1); y++)
                    {
                        temp[y] = _data[y, x];
                        _data[y, x] = _data[y, _data.GetLength(2) - (1 + x)];
                        _data[y, _data.GetLength(2) - (1 + x)] = temp[y];
                    }
                }
            }
        }
    }
}
