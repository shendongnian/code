    public static string TrimWordyText(string source, int totalLength = 200) {
      if (string.IsNullOrEmpty(source))
        return source;
      else if (source.Length <= totalLength)
        return source;
      // let's try trimming on white space (sparing mode)
      int index = 0;
      for (int i = 0; i <= totalLength; ++i) {
        char ch = source[i];
        if (char.IsWhiteSpace(ch))
          index = i;
      }
      // can we save at least 2/3 of text by splitting on white space 
      if (index > totalLength * 2 / 3)
        return source.Substring(0, index) + "...";
      else
        return source.Substring(0, totalLength) + "...";
    }
....
    // "My favorite..." 
    myTextBox.Text = TrimWordyText("My favorite wordy text is it", 15); 
    // "My favorit..." 
    myTextBox.Text = TrimWordyText("My favorite wordy text is it", 10); 
