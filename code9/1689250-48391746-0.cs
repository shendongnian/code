    public partial class Form2 : Form
    {
        int int_player1_religion = 0;  // <=====
        int int_player2_religion = 0;  // <=====
        string string_player1_religion;
        string string_player2_religion;
        public Form2()
        {
            InitializeComponent(); //1 = buddhism, 12 = celtic polytheism 
            button1.Visible = false;
        }
    
        private void pictureBox_buddhism_Click(object sender, EventArgs e)
        {   
            if (int_player1_religion == 0) {
                int_player1_religion = 1; // <===== take out the int
                string string_player1_religion = "buddhism";
                pictureBox2.BackgroundImage = Properties.Resources.religion_buddhism;
                label2.Text = "player 2 choose your religion";
                label3.Text = "";
                pictureBox_buddhism.Visible = false;
                button2.Text = "buddhism";
            }
    
            if (int_player1_religion != 0)
            {
                int_player2_religion = 1;  // <===== take out the int
                string string_player2_religion = "buddhism";
                pictureBox4.BackgroundImage = Properties.Resources.religion_buddhism;
                label2.Text = "start the game";
                label3.Text = "";
                pictureBox_buddhism.Visible = false;
                button3.Text = "buddhism";
                button1.Visible = true;
            }
        }
    
        private void pictureBox_taoism_Click(object sender, EventArgs e)
        {
            if (int_player1_religion == 0)
            {
                int_player1_religion = 2;  // <===== take out the int
                string string_player1_religion = "taoism";
                pictureBox2.BackgroundImage = Properties.Resources.religion_taoism;
                label2.Text = "player 2 choose your religion";
                label4.Text = "";
                pictureBox_taoism.Visible = false;
                button2.Text = "taoism";
            }
            if (int_player1_religion != 0)
            {
                int_player2_religion = 2;  // <===== take out the int
                string string_player2_religion = "taoism";
                pictureBox4.BackgroundImage = Properties.Resources.religion_taoism;
                label2.Text = "start the game";
                label4.Text = "";
                pictureBox_taoism.Visible = false;
                button3.Text = "taoism";
                button1.Visible = true;
            }
        }
    }
