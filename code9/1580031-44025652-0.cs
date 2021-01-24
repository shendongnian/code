    public class TokenCreator
    {
     private Random random = new Random();
     private const string[] chars= "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
     public static string CreateToken(int length)
     {
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
     }
    }
    
    AuthCode = TokenCreator.CreateToken(5);
