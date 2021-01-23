    Random rnd = new Random();
    List<Button> ButtonList = new List<Button>();
    private void timer_spawn_Tick(object sender, EventArgs e)
    {
        Button enemybutton = new Button();
        enemybutton.Click += Enemybutton_Click;
        int sidepick = rnd.Next(1, 5);
        switch (sidepick)
        {
            case 1:
                enemybutton.Left = rnd.Next(1, 15);
                enemybutton.Top = rnd.Next(1, 700);
                break;
            case 2:
                enemybutton.Left = rnd.Next(1, 1000);
                enemybutton.Top = rnd.Next(1, 15);
                break;
            case 3:
                enemybutton.Left = rnd.Next(1, 1315);
                enemybutton.Top = rnd.Next(650, 665);
                break;
            case 4:
                enemybutton.Left = rnd.Next(1300,1315);
                enemybutton.Top = rnd.Next(1, 650);
                break;
            default:
                break;
        }
        enemybutton.Height = 64;
        enemybutton.Width = 64;
        Controls.Add(enemybutton);
        ButtonList.Add(enemybutton);  
        enemiesSpawned++;
        if(enemiesSpawned == levelsBeat)
        {
            levelsBeat++;
            enemiesSpawned = 0;
            timer1.Stop();
        }
      
    }
