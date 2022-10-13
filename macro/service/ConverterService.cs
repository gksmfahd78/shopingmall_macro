using System;
using System.IO;
using System.Drawing;

namespace macro
{
    class ConverterService : IConverter 
    {
        public byte[] bitmap2ByteArray(Bitmap bitmap)
        {
            byte[] result = null;
            if (bitmap != null)
            {
                MemoryStream stream = new MemoryStream();
                bitmap.Save(stream, bitmap.RawFormat);
                result = stream.ToArray();
            }
            else
            {
                Console.WriteLine("Bitmap is null.");
            }
            return result;
        }
    }
}
