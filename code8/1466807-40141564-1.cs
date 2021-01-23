      for (int i = 0; i < MoveBox.Items.Count; i++)
        {
            if (MoveBox.Items[i].ToString() == query1)
            {
                this.MoveRobot(1);
                DoWork();
            }
            if (MoveBox.Items[i].ToString() == query2)
            {
                this.MoveRobot(10);
                DoWork();
            }
           Thread.Sleep(300);
        }
