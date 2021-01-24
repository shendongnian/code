    public sealed class StringGenerator
    {
      private static readonly char[] NumericChars = "0123456789".ToCharArray();
      private static readonly char[] LowerAlphaChars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
      private static readonly char[] UpperAlphaChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
      public StringGenerator(IRandom rnd)
      {
        Rnd = rnd ?? new SecureRandom();
      }
      private IRandom Rnd
      {
        get;
        set;
      }
      public string Generate(int length, int minNumeric = 0, int minAlpha = 0, AlphaCase alphaCase = AlphaCase.Both)
      {
        if (length < 0)
        {
          throw new ArgumentOutOfRangeException("length");
        }
        if (minNumeric < 0)
        {
          throw new ArgumentOutOfRangeException("minNumeric");
        }
        if (minAlpha < 0)
        {
          throw new ArgumentOutOfRangeException("minAlpha");
        }
        if (length < minNumeric + minAlpha)
        {
          throw new ArgumentException();
        }
        if (length == 0)
        {
          return string.Empty;
        }
        var result = new char[length];
        var index = 0;
        foreach(var numeric in GenerateNumeric().Take(minNumeric))
        {
          result[index++] = numeric;
        }
        var alphaCharacters = GetAlphaCharacters(alphaCase);
        foreach (var alpha in Generate(alphaCharacters).Take(minAlpha))
        {
          result[index++] = alpha;
        }
        var restLength = length - index;
        if (restLength > 0)
        {
          var restCharacters = new List<char>(NumericChars.Concat(alphaCharacters));
          foreach (var rest in Generate(restCharacters).Take(restLength))
          {
            result[index++] = rest;
          }
        }
        // shuffle result
        return new string(result.OrderBy(x => Rnd.Next()).ToArray());
      }
      private IList<char> GetAlphaCharacters(AlphaCase alphaCase)
      {
        switch (alphaCase)
        {
          case AlphaCase.Lower:
            return LowerAlphaChars;
          case AlphaCase.Upper:
            return UpperAlphaChars;
          case AlphaCase.Both:
          default:
            return new List<char>(LowerAlphaChars.Concat(UpperAlphaChars));
        }
      }
      public IEnumerable<char> GenerateNumeric()
      {
        return Generate(NumericChars);
      }
      public IEnumerable<char> GenerateLowerAlpha()
      {
        return Generate(LowerAlphaChars);
      }
      public IEnumerable<char> GenerateUpperAlpha()
      {
        return Generate(UpperAlphaChars);
      }
      public IEnumerable<char> Generate(IList<char> characters)
      {
        if (characters == null)
        {
          throw new ArgumentNullException();
        }
        if (!characters.Any())
        {
          yield break;
        }
        while (true)
        {
          yield return characters[Rnd.Next(characters.Count)];
        }
      }
    }
    public enum AlphaCase
    {
      Lower,
      Upper,
      Both
    }
    public interface IRandom
    {
        int Next();
        int Next(int maxValue);
    }
    public sealed class SecureRandom : IRandom
    {
        private readonly RandomNumberGenerator Rng = new RNGCryptoServiceProvider();
        public int Next()
        {
            var data = new byte[sizeof(int)];
            Rng.GetBytes(data);
            return BitConverter.ToInt32(data, 0) & (int.MaxValue - 1);
        }
        public int Next(int maxValue)
        {
            return Next(0, maxValue);
        }
        public int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException();
            }
            return (int)Math.Floor(minValue + ((double)maxValue - minValue) * NextDouble());
        }
        public double NextDouble()
        {
            var data = new byte[sizeof(uint)];
            Rng.GetBytes(data);
            var randomUint = BitConverter.ToUInt32(data, 0);
            return randomUint / (uint.MaxValue + 1d);
        }
    }
