    public delegate void ChangeText(string amountTxt);
    public event ChangeText ChangeTextEvent;
    private void loansToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ChangeTextEvent += new ChangeText(Change_Text)
        Form2 form2 = new Form2();
        form2.ChangeText = ChangeTextEvent;
        form2.ShowDialog();
     }
       
     public Change_Text(string amountTxt)
     {
         textBox39.Text = amountTxt;
     }
