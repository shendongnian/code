    public string yourFunction(double val)
    {
        double x = val;
    
        if (BitConverter.GetBytes(decimal.GetBits((decimal)val)[3])[2] > 2)   //check if there are more than 2 decimal places
        {
            x = Math.Truncate(val * 100) / 100;           
            string s = string.Format("{0:N2}", x);
            return s;
        }
        return x.ToString();
    }
