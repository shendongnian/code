    public static String md5_hash3(String value) {
      using (var hash = MD5.Create()) {
        return String.Concat(hash
          .ComputeHash(Encoding.UTF8.GetBytes(value))
          .Take(3)
          .Select(item => item.ToString("X2")));
      }
    }
...
     String result = md5_hash3(r.Employee.Name); 
