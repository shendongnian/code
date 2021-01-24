    public class MyForm: Form
    {
        protected button1;
        public MyForm()
        {
            button1 = new Button { Text = "Hello World" }; // here
            Controls.Add(button1);
        }
    }
