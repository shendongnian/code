        private void control_MouseMove(object sender, MouseEventArgs e)
        { 
            if (isDragged)
            {
                Point newPoint = ((Control)sender).PointToScreen(new Point(e.X, 
                e.Y));
                newPoint.Offset(ptOffset);
                ((Control)sender).Location = newPoint;
                ((Control)sender).Refresh();
            }
        }
        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && checkBox1.Checked)
            {
                isDragged = true;
                ((Control)sender).MouseMove += new 
                MouseEventHandler(control_MouseMove);
                
                Point ptStartPosition = ((Control)sender).PointToScreen(new 
                Point(e.X, e.Y));
                ptOffset = new Point();
                ptOffset.X = ((Control)sender).Location.X - ptStartPosition.X;
                ptOffset.Y = ((Control)sender).Location.Y - ptStartPosition.Y;
            }
            else
            {
                isDragged = false;
            }
        }
        private void control_MouseUp(object sender, MouseEventArgs e)
        {
            ((Control)sender).MouseMove -= control_MouseMove;
            ((Control)sender).Refresh();
            isDragged = false;
        }
        private void SetupClickEvents(Control control)
        {            
            control.Click += new EventHandler(StoreLastClick);
            control.MouseDown += new MouseEventHandler(control_MouseDown);
            //control.MouseMove += new MouseEventHandler(control_MouseMove);
            control.MouseUp += new MouseEventHandler(control_MouseUp);            
        }
        private void createButton_PB_Click(object sender, EventArgs e)
        {
            ctrlExists = 0;
            string btnName = btnName_TB.Text;
            foreach (Button button in tabControl1.SelectedTab.Controls)
            {
                if (button.Name == btnName)
                {
                    ctrlExists = 1;
                }
            }
            if (btnName_TB.Text != "" && ctrlExists == 0)
            {               
                Button newButton = new Button();
                newButton.Name = btnName.Replace(" ", String.Empty);
                newButton.Text = btnName;
                tabControl1.SelectedTab.Controls.Add(newButton);
                newButton.Left = 10;
                newButton.Top = 420;
                SetupClickEvents(newButton);
            }
        }
        private void deleteButton_PB_Click(object sender, EventArgs e)
        {
            ctrlExists = 0;
            if (lastCtrlClicked != null)
            {
                string btnName = lastCtrlClicked.Name;
                foreach (Button button in tabControl1.SelectedTab.Controls)
                {
                    if (button.Name == btnName)
                    {
                        ctrlExists = 1;
                    }
                }
            }
            if (ctrlExists == 1 && lastCtrlClicked != null)
            {
                tabControl1.SelectedTab.Controls.Remove(lastCtrlClicked);
                lastCtrlClicked.Dispose();
                ctrlExists = 0;
            }
            lastCtrlClicked = null;
        }
