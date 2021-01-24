    public class A
    {
        public method callingmethod()
        {
            ExceptionForm expform = new ExceptionForm();
            expform.ValueSelected += ExceptionForm_ValueSelected;
            expform.Show();
        }
        private void ExceptionForm_ValueSelected(string option)
        {
            string newexp = option;
            // Do whatever you wanted to do next!
        }
    }
