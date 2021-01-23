    private static String ReOrderNamesParts(string name) {
      if (string.IsNullOrEmpty(name))
        return name;
      string[] parts = name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      if (parts.Length <= 0)
        return name;
      StringBuilder sb = new StringBuilder(parts[parts.Length - 1]);
      if (parts.Length > 2) {
        sb.Append(", ");
        sb.Append(parts[0]);
      }
      for (int i = 1; i < parts.Length - 1; ++i) {
        sb.Append(' ');
        sb.Append(parts[i].Substring(0, 1));
        sb.Append('.');
      }
      return sb.ToString();
    }
