    private void button1_Click(object sender, EventArgs e)
                {
                    string libelle = textBox1.Text;
                    string cause = textBox2.Text;
                    string interval = textBox3.Text +'-'+ textBox4.Text;
    
                    d.open();
                  int c =  d.InsertPanne(libelle, cause, interval);
                    if (c == 1)
                    {
                        MessageBox.Show("Panne ajoutée avec succès");
                        
       //Call Update function to update values
    UpdateFormsControls();
                        Form1 f = new Form1();
                        f.Refresh();
    
    
                    }
    
                    d.close();
    
                }
