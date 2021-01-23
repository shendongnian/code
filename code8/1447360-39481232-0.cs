    public partial class TextEditor : TextBox
    {
        public TextEditor()
        {
            this.Font = new Font("Calibri", 12.0f);
            this.BackColor = Color.Gainsboro;
            this.BorderStyle = BorderStyle.FixedSingle;
            
            ReadOnlyChanged += OnReadOnlyChanged;
        }
        private void OnReadOnlyChanged(object sender, EventArgs eventArgs)
        {
            if (ReadOnly)
                BackColor = Color.DarkGray;
        }
        protected override void InitLayout()
        {
            base.InitLayout();
            CharacterCasing = _charCasing;
            //SetStyle(ControlStyles.UserPaint, true);
        }
    }
