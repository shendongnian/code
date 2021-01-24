     // example property
     public string Name { get; set; }
    // at run time it is the same as:
    private string Name;
    public string GetName(){
      return this.Name;
    }
    public string SetName(string name){
      this.Name = name;
    }
