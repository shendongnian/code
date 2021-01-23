    void OnAddLineCommand(object obj)
    {
    //...
    var lineVM = new LineViewModel(this);
    this.Lines.Add(lineVM);
    //...
    } 
