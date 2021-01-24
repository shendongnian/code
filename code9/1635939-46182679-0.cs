        using System.Diagnostics;
        double[] doubleData = new double[500000];
        byte[] loopData;
        byte[] convertData;
        //linq approach
        Stopwatch sw = Stopwatch.StartNew();
        convertData = doubleData.Select(o => Convert.ToByte(o)).ToArray();
        MessageBox.Show(sw.ElapsedMilliseconds.ToString());
        //loop approach
        sw = Stopwatch.StartNew();
        loopData = new byte[doubleData.Length];
        for (int i = 0; i<doubleData.Length; ++i)
        {
            loopData[i] = (byte)(doubleData[i]);
        }
        MessageBox.Show(sw.ElapsedMilliseconds.ToString());
