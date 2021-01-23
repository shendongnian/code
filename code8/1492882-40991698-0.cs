    public static string ToText(this string str)
    {
      var result = new StringBuilder();
      var dtable = "4\rw+6d\b2aQ9\025\006Lu35\"$xPS)[@Y\024'G7U\001c\000W>1ti*=\021\020kB&\004e\019\031pE%D`H\003.<\016\026\023\017bN:\a,8(jm{\028r\014l- ]v\002f|\029R\vZy\005V^\n#C}~g_oz;\030hO\\As\f0!/X?\tMq\022IKTn\018\027J\015F";
    
    foreach(Char c in str)
    {
      var byteValue = Convert.ToByte(c);
      if(byteValue > 0 && byteValue <= 127(
      {
        result.Append(dtable[byteValue]);
      }
      else
      {
        result.Append(c);
      }
     }
    
    return result;
    }
