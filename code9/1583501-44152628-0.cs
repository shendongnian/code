    public static string Hash(string input)
    {
        using (SHA1Managed sha1 = new SHA1Managed())
        {
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sb = new StringBuilder(hash.Length * 2);
    
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2")); // x2 is lowercase
            }
    
            return sb.ToString().ToLower();
        }
    }
    public static void Main()
    {
        var x  ="callerId1495611935​apiKey{[B{+%P)s;WD5&5x";
        Console.WriteLine(Hash(x)); // prints 7e81e0d40ff83faf1173394930443654a2b39cb3
    }
