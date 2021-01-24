    public double [,] CreateIPmathCurve(string comboBoxName)
        {
            
            string CurveInText = "";
            char[] delimiter = { ':' };
            CurveInText = comboBoxName;
            string[] crvIn = CurveInText.Split(delimiter);
            string CurveSet = crvIn[0];
            string Curve = crvIn[1];
            ICurveSet InCurveSet = myWell.FindCurveSet(CurveSet);
            ICurve InMyCurve = myWell.FindCurve(Curve);
            if (InMyCurve == null)
            {
                MessageBox.Show("You need to input a curve");
            }
            ILogReading[] In = InMyCurve.LogReadings.ToArray();
            double[,] CurveDouble = new double[In.Length, 2];
            int j = 0;
            foreach (ILogReading reading in InMyCurve.LogReadings)
            {
                CurveDouble[j, 0] = reading.Depth;
                CurveDouble[j, 1] = reading.Value;
                j++;
            }
            return CurveDouble;
