    private double getTotal(string str)
            {
                double total = 0;
                byte[] asciiBytes = Encoding.ASCII.GetBytes(str);
    
                foreach (int c in asciiBytes)
                {
                    total = total + c;
                    total = total * (5 * (double)(c ^ 2) / (double)(c * 6));
                }
                return Math.Round(total);
            }
