        private void button1_Click(object sender, EventArgs e)
                {
                    FormCollection fc = Application.OpenForms;
                    bool present = false;
        
                    foreach (Form frm in fc)
                    {
        
                        if (frm.Name == "Form2")
                        {
                            present = true;
                        }
                    }
        
                    if (!present)
                    {
                        Form2 f2 = new Form2();
                        f2.Show();
                    }
                }
    
