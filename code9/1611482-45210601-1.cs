		private string _text;
	private Image _icon;
	
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
		
	    _text = this.text;
            _icon = this.icon;
            if (icon != null)
            {
                iconAvailable = true;
                this.Image = this.icon; //Here I Need to get the icon value here,                }
            if (text != string.Empty || this.text != null)
            {
                textAvailable = true;
                this.Text = this.text;// // Here Need to get the text value here, Not completed
            }
            //align icon and text on booleans
            setControlAlignment(this.text, this.icon);
        }
        private void setControlAlignment(string text, Image icon);
        {
           HorizontalAlignment textPos;
           HorizontalAlignment iconPos;
           if (!string.IsNullOrWhiteSpace(text) && this.icon != null)		// If we have both text and icon values
           {
		textPos = HorizontalAlignment.Left;
                iconPos = HorizontalAlignment.Right;
           }
	   else if (string.IsNullOrWhiteSpace(this.text) && this.icon != null)
	   {
		iconPos = HorizontalAlignment.Center;
           }
	   else if (!string.IsNullOrWhiteSpace(this.text) && this.icon == null)
	   {
		textPos = HorizontalAlignment.Center;
           }
	   // and whatever else you want to do...
        }
