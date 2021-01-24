    public void button2_Click(object sender, EventArgs e)
    {
      if (radioButton1.Checked)
      { 
        ComicBooks CB = new ComicBooks();
        CB.setTitle(textBox1.Text);
        MessageBox.Show(CB.Title);
      }
      else if (radioButton2.Checked)
      { 
        // do something
      }
      else if (radioButton3.Checked)
      { 
        // do something
      }
    }
