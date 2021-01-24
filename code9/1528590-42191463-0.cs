    public partial class secondclass: Form
    {
          public secondclass(firstclass first)
          {
               // firstclass first=new firstclass();
               MessageBox.Show(first.comboBox1.Items.Count.ToString())
          }
    }
    public partial class firstclass: Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            secondclass second = new secondclass(this); // Pointer to first class
        }
    }
