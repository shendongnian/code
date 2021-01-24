    public class MyClass
    {
        public void ChangeBackgroundColor(Form f)
        {
            foreach (Control item in f.Controls)
            {
            
                if (item is ComboBox)
                {
            
                }
                else
                {
                    item.BackColor = Color.White;
                }
            }
            f.BackColor = Color.White;
        }
    }
