    public static String md5_hash(String value) {
      using (var hash = MD5.Create()) {
        return String.Join("", hash
          .ComputeHash(Encoding.UTF8.GetBytes(value))
          .Take(3)
          .Select(item => item.ToString("x2")));
      }
    }
