    private void Form1_Load(object sender, System.EventArgs e)
    {  
         pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
    }
    private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    { 
          pictureBox1.Top -= 8;
    }
