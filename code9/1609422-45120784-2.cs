    public class Function
    {
        public void Plus(Form1 form)
        {
            decimal multiple = 0.3m;
            decimal digit = Convert.ToDecimal(form.TextBox1Text);
            form.TextBox2Text = String.Format("{0:f}", (digit * multiple) + digit);
        }
    }
