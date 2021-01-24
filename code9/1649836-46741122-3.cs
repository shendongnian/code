    private async void button1_Click(object sender, EventArgs e)
    {
      // Task.Run() requires "using System.Threading.Tasks;"
      string returnString = await Task.Run(() => client.GetData(textBox1.Text));
      label1.Text = returnString;
    }
 
