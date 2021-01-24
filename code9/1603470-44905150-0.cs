    public static class IListExtension
    {
      public static string ToDisplay(this IList source, string seperator = ",")
      {
        string display = string.Empty;
        // create the display string from the elements of this list
        return display;
      }
    }
    public string CreateDisplayString(object element)
    {
      if (element == null)
        return string.Empty;
      if (element is Ilist)
        return (element as IList).ToDisplay();
      return element.ToString();
    } 
