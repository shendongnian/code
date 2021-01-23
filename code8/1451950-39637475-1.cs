     private void button1_Click(object sender, EventArgs e)
            {
                FormCollection fc = Application.OpenForms;
                bool present = false;
    
                foreach (Form frm in fc)
                {
                    
                    if (frm.Name == "Form1")
                    {
                        present = true;
                    }
                }
    
                if (!present)
                {
                    Form1 f1 = new Form1();
                    f1.Show();
                }
            }
