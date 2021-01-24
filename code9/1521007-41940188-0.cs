      string result = string.Join("," + Environment.NewLine, Clipboard
        .GetText()
        .Split(new String[] { Environment.NewLine }, StringSplitOptions.None)
        .Select(line => "\"" + line + "\""));
      Clipboard.SetText(result);
