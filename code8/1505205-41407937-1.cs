        public void Closest_Standard_Value(double val)
        {
            val = val * Math.Pow(10, -(val.ToString().Length - 1));
            while (E12[i + 1] <= val)
            {
                i++;
            }
        }
