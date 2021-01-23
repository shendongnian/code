    private string GetCodePart()
    {
      string str = "Shouldly uses your source code to generate its great error messages, build your test project with full debug information to get better error messages\nThe provided expression";
      if (this._determinedOriginatingFrame)
      {
        string codeLines = string.Join("\n", ((IEnumerable<string>) File.ReadAllLines(this.FileName)).Skip<string>(this.LineNumber).ToArray<string>());
        int indexOfMethod = codeLines.IndexOf(this._shouldMethod);
        if (indexOfMethod > 0)
          str = codeLines.Substring(0, indexOfMethod - 1).Trim();
        str = !str.EndsWith("Should") ? str.RemoveVariableAssignment().RemoveBlock() : this.GetCodePartFromParameter(indexOfMethod, codeLines, str);
      }
      return str;
    }
