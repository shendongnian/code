    public static class Check
    {
        public static (string MyName, string YourName) MyValue(string qr)
        {
            return ($"My Name {qr}", $"You're {qr}");
        }
    }
