    private void pictureBox1_Click(object sender, EventArgs e)
        {
            var label1 = new LabelControl();
            label1.Location = imgRoom.PointToClient(MousePosition);  // changed here.
            label1.BackColor = Color.Red;
            label1.Parent = imgRoom;
            label1.Text = "Point";
            imgRoom.Controls.Add(label1);
        }
