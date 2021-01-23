     List<example> examleArray = new List<example>();
     private void button1_Click(object sender, EventArgs e)
     {
       if (examleArray.Any(e=>e.Name == textBox1.Text))
       {
         MessageBox.Show("Name taken!");
       } else {
         examleArray.Add(new example { Name = textBox1.Text });
       }
     }
