using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation
{
    public interface IImageSerializer
    {
        String Serialize(Image i);
        Image Parse(String imageData);
    }
}

