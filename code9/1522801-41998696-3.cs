    public static class Check
    {
        public static Tuple<string, string> MyValue(string qr)
        {
            return Tuple.Create($"My Name {qr}", $"You're {qr}");
        }
    }
