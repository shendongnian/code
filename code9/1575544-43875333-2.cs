        int tileSize = tiff.TileSize();
        for (int iw = 0; iw < nWidth; iw += tilew)
        {
          for (int ih = 0; ih < nHeight; ih += tileh)
          {
            byte[] buffer = new byte[tileSize];
            tiff.ReadTile(buffer, 0, iw, ih, 0, 0);
            for (int itw = 0; itw < tilew; itw++)
            {
              int iwhm = ih + itw;
              if (iwhm > nWidth - 1)
              {
                break;
              }
              for (int ith = 0; ith < tileh; ith++)
              {
                int iyhm = iw + ith;
                if (iyhm > nHeight - 1)
                {
                  break;
                }
                heightMap[iwhm, iyhm] =
                  BitConverter.ToSingle(buffer, (itw * tileh + ith) * 4);
              }
            }
          }
        }
