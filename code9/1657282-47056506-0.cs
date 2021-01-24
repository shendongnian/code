    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    namespace DrawingImagingOperations
    {
        class Program
        {
            static void Main(string[] args)
            {
                Bitmap foreImg = new Bitmap(@"..\..\YaHI9.jpg");
                //output image
                Bitmap resImg = new Bitmap(foreImg.Width, foreImg.Height, foreImg.PixelFormat);
                unsafe
                {
                    BitmapData oneBits = foreImg.LockBits(new Rectangle(0, 0, foreImg.Width, foreImg.Height), ImageLockMode.ReadOnly, foreImg.PixelFormat);
                    BitmapData thrBits = resImg.LockBits(new Rectangle(0, 0, resImg.Width, resImg.Height), ImageLockMode.WriteOnly, resImg.PixelFormat);
                    int pixelSize = GetPixelSize(foreImg.PixelFormat);
                    var byteLength = foreImg.Width * foreImg.Height * pixelSize;
                    var length = byteLength / sizeof(UInt64);
                    var reminder = byteLength % sizeof(UInt64);
                    System.Threading.Tasks.Parallel.For(0, length, j =>
                    {
                        ulong* pxOne = (ulong*)((byte*)oneBits.Scan0 + j * sizeof(UInt64));
                        ulong* pxRes = (ulong*)((byte*)thrBits.Scan0 + j * sizeof(UInt64));
                        *pxRes = *pxOne;
                    });
                    if (reminder > 0)
                    {
                        byte* pSrc = (byte*)oneBits.Scan0 + (pixelSize * length);
                        byte* pDst = (byte*)thrBits.Scan0 + (pixelSize * length);
                        for (int j = length; j < byteLength; j++)
                            *pDst++ = *pSrc++;
                    }
                    foreImg.UnlockBits(oneBits);
                    resImg.UnlockBits(thrBits);
                }
                resImg.Save(@"..\..\imgCopy.jpg");
            }
            internal static int GetPixelSize(PixelFormat data)
            {
                switch (data)
                {
                    case PixelFormat.Format8bppIndexed:
                        return 1;
                    case PixelFormat.Format16bppGrayScale:
                    case PixelFormat.Format16bppRgb555:
                    case PixelFormat.Format16bppRgb565:
                    case PixelFormat.Format16bppArgb1555:
                        return 2;
                    case PixelFormat.Format24bppRgb:
                        return 3;
                    case PixelFormat.Canonical:
                    case PixelFormat.Format32bppArgb:
                    case PixelFormat.Format32bppPArgb:
                    case PixelFormat.Format32bppRgb:
                        return 4;
                    case PixelFormat.Format48bppRgb:
                        return 6;
                    case PixelFormat.Format64bppArgb:
                    case PixelFormat.Format64bppPArgb:
                        return 8;
                }
                throw new FormatException("Unsupported image format: " + data);
            }
        }
    }
   
