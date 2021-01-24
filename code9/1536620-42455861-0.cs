     class Class1 {
    private string _Text;
                public Class1(){
               _Text = this.ToString();
            }
            public override string ToString() {
                return "Hello, WPF!";
            }
        }
    public string Text
            {
                get{return _Text;}
                protected set { _Text = value;
                NotifyPropertyChanged("Text");
                }
            }
