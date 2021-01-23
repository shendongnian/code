    try
    {
         m_pImageData = TempStorage.LockBits(new Rectangle(0, 0, TempStorage.Width, TempStorage.Height),
                                                 System.Drawing.Imaging.ImageLockMode.ReadWrite,
                                                 System.Drawing.Imaging.PixelFormat.Format24bppRgb);
    
         System.IntPtr pScan = m_pImageData.Scan0; // 5
         int nStride = m_pImageData.Stride;// 6
         ActualByte = new byte[m_pImageData.Height * m_pImageData.Width * 3];
    
         unsafe
         {
              byte* pBuffer = (byte*)(void*)pScan;// 7
    
              int noffset = nStride - TempStorage.Width * 3;
    
              int count = 0;
              for (int nY = 0; nY < TempStorage.Height; nY++)
              {
                   for (int nX = 0; nX < TempStorage.Width; nX++)
                   {
    
                        ActualByte[count] = pBuffer[0];
                        ActualByte[count + 1] = pBuffer[1];
                        ActualByte[count + 2] = pBuffer[2];
                        count += 3;
                        pBuffer += 3;
                   }
                   pBuffer += noffset;
                }
            }
        }
    finally
    {
         if (m_pImageData != null)
         {
             TempStorage.UnlockBits(m_pImageData);
         }
    }
