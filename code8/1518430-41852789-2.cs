        public void Btn1_Click(object sender, EventArgs e)
    
        {
            Form2 f2 = new Form2(); 
            f2.ShowDialog();
            if ((f2.Passvalue.Length > 0) && (f2.Passvalue2.Length > 0))
            {
                trenutnoStanjeTB.Text = f2.Passvalue;//trenutnostanjeTB=textbox(form1)=gets number from form2
                DinEuLab1.Text = f2.Passvalue2;//dineulab1=label form1=gets the eur text
                DinEuLab2.Text = f2.Passvalue2;
            }
    
        }
