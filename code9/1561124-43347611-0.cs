    public string GetGeneratedCode()
    {
      MyTemplate temp = new MyTemplate (); //<- another T4 template
      return temp.TransformText().Replace(Environment.NewLine, "\\r\\n");
    }
