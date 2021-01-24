    int count = 0;
    private void button1_Click(object sender, EventArgs e)
    {
        if (count == 0)
        {
            //Make PictureBox3 visible
            pictureBox1.Visible = true;
            count++;
        }
        else if (count == 1)
        {
            //Make PictureBox visible
            pictureBox2.Visible = true;
            count++;
        }
        else if (count == 2)
        {
            //Make PictureBox3 visible
            pictureBox3.Visible = true;
            count++;
        }
        else if (count == 3)
        {
            //Hide all PictureBoxes again
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            count = 0;
        }
    }
