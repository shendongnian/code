            public customButton() : this(null, null)
            {
            }
    
    
            /// <summary>
            /// This constructor will call when button contains Text property only.
            /// call the base constructor with Image is null.
            /// </summary>
            /// <param name="text"></param>
            public customButton(string text) : this(text, null)
            {
            }
    
    
            /// <summary>
            /// This constructor will call when button contains Image property only.
            /// call the base constructor with text is null.
            /// </summary>
            /// <param name="icon"></param>
            public customButton(Image icon) : this(null, icon)
            {
            }
    
    
            /// <summary>
            /// This constructor will call when button contains both image and text values.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="icon"></param>
            public customButton(string text, Image icon)
            {
                InitializeComponent();
                if (icon != null)
                {
                    iconAvailable = true;
                    this.Image = icon; //Here I Need to get the icon value here,                }
                if (text != string.Empty || text != null)
                {
                    textAvailable = true;
                    this.Text = text;// // Here Need to get the text value here, Not completed
                }
    
                //align icon and text on booleans
                setControlAlignment();
            }
