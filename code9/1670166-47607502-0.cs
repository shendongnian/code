    Form2 form
    private void btn1_Click(object sender, EventArgs e)
        {
            form = new Form2();
            form.Show();
        }
    
    private void btn2_Click(object sender, EventArgs e)
        {
            if(form != null && !form.IsDisposed){
                  form.Close();
            }
        }
