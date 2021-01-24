    using System;
    using System.Drawing;
    using System.Windows;
    using SWM = System.Windows.Media;
    using SWMI = System.Windows.Media.Imaging;
    public class GdiGraphicsWriteableBitmap
    {
        readonly Action<Rectangle, Graphics> m_draw;
        SWMI.WriteableBitmap m_wpfBitmap = null;
        Bitmap m_gdiBitmap = null;
        public GdiGraphicsWriteableBitmap(Action<Rectangle, Graphics> draw)
        {
            if (draw == null) { throw new ArgumentNullException(nameof(draw)); }
            m_draw = draw;
        }
        public SWMI.WriteableBitmap WriteableBitmap => m_wpfBitmap;
        public bool IfNewSizeResizeAndDraw(int width, int height)
        {
            if (m_wpfBitmap == null ||
                m_wpfBitmap.PixelHeight != height ||
                m_wpfBitmap.PixelWidth != width)
            {
                Reset();
                // Can't dispose wpf
                const double Dpi = 96;
                m_wpfBitmap = new SWMI.WriteableBitmap(width, height, Dpi, Dpi,
                    SWM.PixelFormats.Bgr24, null);
                var ptr = m_wpfBitmap.BackBuffer;
                m_gdiBitmap = new Bitmap(width, height, m_wpfBitmap.BackBufferStride,
                    System.Drawing.Imaging.PixelFormat.Format24bppRgb, ptr);
                Draw();
                return true;
            }
            return false;
        }
        
        public void Draw()
        {
            if (m_wpfBitmap != null)
            {
                m_wpfBitmap.Lock();
                int width = m_wpfBitmap.PixelWidth;
                int height = m_wpfBitmap.PixelHeight;
                {
                    using (var g = Graphics.FromImage(m_gdiBitmap))
                    {
                        m_draw(new Rectangle(0, 0, width, height), g);
                    }
                }
                m_wpfBitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
                m_wpfBitmap.Unlock();
            }
        }
        // If window containing this is not shown, one can Reset to stop draw or similar...
        public void Reset()
        {
            m_gdiBitmap?.Dispose();
            m_wpfBitmap = null;
        }
    }
