    private Model model;
    public Model Model
    {
        get { return model; }
        set 
        { 
          model = value;
          this.PropertyChanged();
        }
    }
