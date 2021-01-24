    [Editor(typeof(MultilineTextBoxEditor), typeof(MultilineTextBoxEditor))]
    public override string Caption
       {
          get
                {
                    return caption;
                }
    
          set
                {
                    caption = value;
                    OnPropertyChanged("Caption");
                }
      }
