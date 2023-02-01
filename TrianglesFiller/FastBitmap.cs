using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace TrianglesFiller
{
    public class FastBitmap : IDisposable
    {
        protected Bitmap Bitmap { get; set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public Int32[] Bits { get; private set; }
        protected GCHandle BitsHandle { get; private set; }
        public FastBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, 4 * width, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }
        public void SetPixel(int x, int y, Color color)
        {
            int index = x + (y * Width);
            Bits[index] = color.ToArgb();
        }
        public Bitmap GetBitmap() => this.Bitmap;
        public void Dispose()
        {
            BitsHandle.Free();
            if (Disposed) return;
            Disposed = true;
            Bitmap?.Dispose();
        }
    }
}