    private static string Crypto(string PhraseAEncoder, int shift)
    {
      string Alphabet = "abcdefghijklmnopqrstuvwxyz";
      StringBuilder result = new StringBuilder(PhraseAEncoder.Length);
      foreach (char c in PhraseAEncoder)
      {
        int code = Alphabet.IndexOf(c);
        if (code < 0)
          result.Append(c);
        else
        {
          code += shift;
          if (code >= Alphabet.Length)
            code %= Alphabet.Length;
          else
          {
            while (code < 0)
              code += Alphabet.Length;
          }
          result.Append(Alphabet[code]);
        }
      }
      return result.ToString();
    }
