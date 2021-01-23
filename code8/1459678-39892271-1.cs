                int screens = Screen.AllScreens.Count();
                this.monitorLayoutPanel.ColumnStyles.Clear();
                this.monitorLayoutPanel.ColumnCount = screens;            
                this.monitorLayoutPanel.AutoSize = true;
                int z = 0;
                foreach (var screen in Screen.AllScreens.OrderBy(i => i.Bounds.X))
                {
                    var percent = 100f / screens;
                    this.monitorLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent));
                    
                    Button monitor = new Button
                    {
                        Name = "Monitor" + screen,
                        Size = new Size(95, 75),
                        BackgroundImageLayout = ImageLayout.Stretch,                                                  
                        BackgroundImage = Properties.Resources.display_enabled,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        ForeColor = Color.White,
                        BackColor = Color.Transparent,
                        Text = screen.Bounds.Width + "x" + screen.Bounds.Height,
                        Anchor = System.Windows.Forms.AnchorStyles.None
                    };
                    
                    this.monitorLayoutPanel.Controls.Add(monitor, z, 0);
                    z++;
                    monitor.MouseClick += new MouseEventHandler(monitor_Click);
