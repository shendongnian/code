    private static System.Security.Cryptography.RandomNumberGenerator random = System.Security.Cryptography.RandomNumberGenerator.Create();
    public static string Random(int characters)
            {
                var data = new byte[characters];
                random.GetBytes(data);
                return data.Select(b=>Convert.ToChar((int)(96 + (Math.Floor((b/(double)byte.MaxValue)*27)) - 1))).Aggregate(new System.Text.StringBuilder(),(a,c) => a.Append(c)).ToString();
            }
