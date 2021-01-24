    public partial class MyButton : Button
    {
        public MyButton()
        {
            InitializeComponent();
        }
        private Form GetParentForm(Control current)
        {
            // if the current is a form, return it.
            if (current is Form)
                return (Form)current;
            // if the parent of the current not is null, 
            if (current.Parent != null)
                // check his parent.
                return GetParentForm(current.Parent);
            // there is no form found.
            return null;
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            // find the parent form.
            var form = GetParentForm(this);
            // if a form was found, 
            if (form != null)
                // check if this is set as accept button
                if (this == form.AcceptButton)
                    // for example, change the background color (i used for testing)
                    this.BackColor = Color.RosyBrown;
        }
    }
