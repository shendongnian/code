        public double Closest_Standard_Value(double val)
        {
            int decimals = ((int)val).ToString().Length - 1;
            val = val * Math.Pow(10, -decimals);            
            while (E12[i + 1]<= val)
                i++;
            return E12[i]*Math.Pow(10, decimals);
        }
 
 
