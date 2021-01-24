    class Animator
    {
        private Form1 _form;
        
        public Animator(Form1 form)
        {
            _form = form;
            _form.MouseClick += Mouse_Clicked;
            // rest of code ommitted...
