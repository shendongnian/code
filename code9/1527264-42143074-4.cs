    private void Form1_Load(object sender, EventArgs e)
    {
        using(Form2 f2 = new Form2())
        {
            if (f2.ShowDialog() != DialogResult.OK)
               return;
         
            LabelText = f2.SomeValue;   
        }
    }
