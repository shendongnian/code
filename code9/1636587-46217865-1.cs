    public static readonly BindableProperty NameProperty = BindableProperty.Create(
     propertyName: "Name",
     returnType: typeof(string),
     declaringType: typeof(MyWebView),
     defaultValue: default(string));
    
         public string Name
         {
             get { return (string)GetValue(NameProperty); }
             set { SetValue(NameProperty, value); }
         }
    
     }
