    public string HintText
        {
            get { return (string)GetValue(HintTextProperty); }
            set { SetValue(HintTextProperty, value); }
        }
        public static readonly DependencyProperty HintTextProperty =
            DependencyProperty.Register(
                "HintText",
                typeof(string),
                typeof(HintTextBox),
                new FrameworkPropertyMetadata(null,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,(sender,e)=>{
                    
                    //Set Break Point Here
                
                });
