    int obstacleX = Convert.ToInt32(lbl.Location.X) - 14;
    int obstacleY = Convert.ToInt32(lbl.Location.Y) + 6;
    PictureBox obstacle = new PictureBox();
    if (Library.GlobalVariables.obstacleStats[i][1] < 0)
    {
        obstacle.Image = Properties.Resources.badObstacle;
    }
    else
    {
        obstacle.Image = Properties.Resources.goodObstacle;
    }
    obstacle.Location = new Point(obstacleX, obstacleY);
    obstacle.Size = new Size(17, 17);
    obstacle.SizeMode = PictureBoxSizeMode.Zoom;
    this.Controls.Add(obstacle);
    obstacle.Show();
    obstacle.BringToFront();
