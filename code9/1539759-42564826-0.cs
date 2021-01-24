        protected void btn_Add_Click(object sender, EventArgs e)
        {
            var textBox = GridView1.FooterRow.FindControl("ntxt_Name") as TextBox;
            if (textBox != null)
            {
                var value = textBox.Text;
                // insert operation
            }
        }
