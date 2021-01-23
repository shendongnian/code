    public static class SetRandomCode
    {
        public static string setCode(List<string> randomCodes)
        {
            randomCodes.Add("Test");
            randomCodes.Add("Test 2");
            randomCodes.Add("Test 3");
            Random r = new Random();
            int index = r.Next(0, randomCodes.Count);
            return randomCodes[index];
        }
    }
