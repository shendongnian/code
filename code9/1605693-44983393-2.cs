    private void Form1_Load(object sender, EventArgs e)
    {
     textBox1.TextChanged += textBox1_TextChanged;
    }
        
    void textBox1_TextChanged(object sender, EventArgs e)
    {
     var txtBox = sender as TextBox;
     if (txtBox == null) return;
     var count = Convert.ToInt16(txtBox.Text);
     //
     var xPosition = 0;
     for (var i = 1; i <= count; i++)
     {
      var button = new Button
      {
       Tag = string.Format("Btn{0}", i),
       Text = string.Format("Button{0}",i),                        
       Location = new Point(xPosition, 0)
      };
     xPosition = xPosition + 100;
     Controls.Add(button);
    }
