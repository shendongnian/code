    public partial class Form1 : Form
    {
        System.Collections.ArrayList arrayList = new System.Collections.ArrayList();
        
        // code if any...
        private void button8_Click(object sender, EventArgs e)
        {
            foreach (object item in checkedListBox1.CheckedItems)
            {
                arrayList.Add(item.ToString());
            }
        }
    }
