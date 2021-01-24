    using System;
    using BitMiracle.LibTiff.Classic;
    using System.IO;
    
    namespace GeoTIFFReader
    {
      public class GeoTIFF
      {
        private float[,] heightMap;
    
        public float[,] HeightMap
        {
          get { return heightMap; }
          private set { heightMap = value; }
        }
        private int nWidth;
    
        public int NWidth
        {
          get { return nWidth; }
          private set { nWidth = value; }
        }
        private int nHeight;
    
        public int NHeight
        {
          get { return nHeight; }
          private set { nHeight = value; }
        }
        private double dW;
    
        public double DW
        {
          get { return dW; }
          private set { dW = value; }
        }
        private double dH;
    
        public double DH
        {
          get { return dH; }
          private set { dH = value; }
        }
        private double startW;
    
        public double StartW
        {
          get { return startW; }
          private set { startW = value; }
        }
        private double startH;
    
        public double StartH
        {
          get { return startH; }
          private set { startH = value; }
        }
    
    
        public GeoTIFF(string fn)
        {
          using (Tiff tiff = Tiff.Open(fn, "r"))
          {
            if (tiff == null)
            {
              // Error - could not open
              return;
            }
    
            nWidth = tiff.GetField(TiffTag.IMAGEWIDTH)[0].ToInt();
            nHeight = tiff.GetField(TiffTag.IMAGELENGTH)[0].ToInt();
            heightMap = new float[nWidth, nHeight];
            FieldValue[] modelPixelScaleTag = tiff.GetField(TiffTag.GEOTIFF_MODELPIXELSCALETAG);
            FieldValue[] modelTiePointTag = tiff.GetField(TiffTag.GEOTIFF_MODELTIEPOINTTAG);
            
            byte[] modelPixelScale = modelPixelScaleTag[1].GetBytes();
            dW = BitConverter.ToDouble(modelPixelScale, 0);
            dH = BitConverter.ToDouble(modelPixelScale, 8) * -1;
    
            byte[] modelTransformation = modelTiePointTag[1].GetBytes();
            double originLon = BitConverter.ToDouble(modelTransformation, 24);
            double originLat = BitConverter.ToDouble(modelTransformation, 32);
    
            startW = originLon + dW / 2.0;
            startH = originLat + dH / 2.0;
    
            FieldValue[] tileByteCountsTag = tiff.GetField(TiffTag.TILEBYTECOUNTS);
            long[] tileByteCounts = tileByteCountsTag[0].TolongArray();
    
            FieldValue[] bitsPerSampleTag = tiff.GetField(TiffTag.BITSPERSAMPLE);
            int bytesPerSample = bitsPerSampleTag[0].ToInt() / 8;
    
    
            FieldValue[] tilewtag = tiff.GetField(TiffTag.TILEWIDTH);
            FieldValue[] tilehtag = tiff.GetField(TiffTag.TILELENGTH);
            int tilew = tilewtag[0].ToInt();
            int tileh = tilehtag[0].ToInt();
    
            int tileWidthCount = nWidth / tilew;
            int remainingWidth = nWidth - tileWidthCount * tilew;
            if (remainingWidth > 0)
            {
              tileWidthCount++;
            }
    
            int tileHeightCount = nHeight / tileh;
            int remainingHeight = nHeight - tileHeightCount * tileh;
            if (remainingHeight > 0)
            {
              tileHeightCount++;
            }
    
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
          }
        }
      }
    }
