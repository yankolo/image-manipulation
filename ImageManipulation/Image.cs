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
    }
}
