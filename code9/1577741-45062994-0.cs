    BitmapData bmpData = m_ImageArray[range.Item1].LockBits(new Rectangle(0, 0, m_ImageArray[range.Item1].Width, m_ImageArray[range.Item1].Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
                  IntPtr scan = bmpData.Scan0;
                  for (int i = 0; i < m_ImageArray[range.Item1].Height; i++)
                  {
                     System.Runtime.InteropServices.Marshal.Copy(RawBitmapImage.Data, i * ImageWidth + range.Item1 * firstBitmapWidth, scan, m_ImageArray[range.Item1].Width);
                     scan += bmpData.Stride;
                  }
                  m_ImageArray[range.Item1].UnlockBits(bmpData);
