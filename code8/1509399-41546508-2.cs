    public static string WE(string Date)
        {
            try
            {
                return DateTime.Parse(Date).ToString();
            }
            catch (FormatException ex)
            {
                return "Invalid Date";
            }
        }
