    public class Form1
    {
        private Form2 _form2;
        public event Action NextStringChanged;
        public class Form1()
        {
           _form2 = new Form2(this);
        }
       private void LongProcess()
       {
          _form2.Show();
          // do long process
         if (NextStringChanged != null)
         {
          NextStringChanged.Invoke(ListBox1.Items[ListBox1.TopIndex].ToString());
         }
       }
    }
    public class Form2
    {
       public class Form2(Form1 form1)
       {
          form1.NextStringChanged += OnNextStringChanged;
       }
       private void OnNextStringChanged(string value)
       {
          // Update WPF user control here
       }
    }
