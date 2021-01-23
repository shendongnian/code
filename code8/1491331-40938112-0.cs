    private void button1_Click(object sender, EventArgs e)
            {
                example temp = new example();
                temp.Name = textBox1.Text;         
                NameTaken = false;
    
                for (var i = 0; i < (examleArrayIndex); i++)
                {
                    if (examleArray[i].Name == temp.Name)
                    {
                        NameTaken = true;
                        MessageBox.Show("Name taken!");
                    }
    
                }
    
                if (NameTaken == false)
                {
                    examleArray[examleArrayIndex] = temp;
                    examleArrayIndex++;
                }
            }
