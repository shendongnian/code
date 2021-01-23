        public void Closest_Standard_Value(double val)
        {
            while (E12[i + 1] * Math.Pow(10, val.ToString().Length - 1) <= val)
            {
                i++;
            }
        }
