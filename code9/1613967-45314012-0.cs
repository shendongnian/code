        for (int T = 0; T < Samples; T++)
        {
          short Sample = System.Convert.ToInt16(A * Math.Sin(DeltaFT * T));
          BW.Write(Sample);
          BW.Write(Sample);
        }
