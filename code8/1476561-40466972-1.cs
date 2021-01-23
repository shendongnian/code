    public class AddNewItemForm : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            if (error == true)
            {
                error_msg_form emf = new error_msg_form();
                emf.Show();
            }
            else
            {
                database_function df = new database_function();
                bool isAdded = df.database_connect(item_code_tb.Text,
                                                   des_tb.Text, 
                                                   unit_tb.Text,
                                                   Convert.ToDouble(unit_price_tb.Text));
                if(isAdded)
                {
                    this.DialogResult = DialogResult.Ok;
                }
            }
        }             
    }
