    public class MeTextBox : TextBox
    {
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                //base.Text = value; // use it or not .. whatever
                MyTextWasChanged();
            }
        }
        void MyTextWasChanged()
        {
            String name;
            name="sachin";
            //text.Text = name;
            base.Text = name;
            MessageBox.Show("" + text.Text);  
        }
    }
