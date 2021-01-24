        private void checkEndGame()
        {
            var endGame = false;
            foreach (Point trail in bothtrail)
            {
                var rect = new Rectangle(trail, new Size(15, 15));
                if (p2.Bounds.IntersectsWith(rect) && p2trail.Count > 1)
                {
                    tmr1.Stop();
                    endGame = true;
                    MessageBox.Show("Player 1 perdio");
                    break;
                }
                else if (p1.Bounds.IntersectsWith(rect) && p1trail.Count > 1)
                {
                    tmr1.Stop();
                    endGame = true;
                    MessageBox.Show("Player 2 perdio"); //Wont Stop Showing Message Box
                    break;
                }
            }
            if (!endGame)
            {
                if (p1.Left < 0 || p1.Top < 0 || p1.Left > this.Width || p1.Top > this.Height)
                {
                    tmr1.Stop();
                    endGame = true;
                    MessageBox.Show("Player1 perdio");
                }
                else if (p2.Left < 0 || p2.Top < 0 || p2.Left > this.Width || p2.Top > this.Height)
                {
                    tmr1.Stop();
                    endGame = true;
                    MessageBox.Show("Player2 perdio");
                }
            }
        
            if (endGame)
            {
                newGame();
            }
        }
