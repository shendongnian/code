    public partial class Form1 : Form
    { 
        bool button1on = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if(button1on)
            {
                button1on = false;
                button11.Text = "Off";
                button11.BackColor = Color.LightGray;
            }
            else
            {
                button1on = true;
                button11.Text = "On";
                button11.BackColor = Color.DimGray;
            }
        }
    }
