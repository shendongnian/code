     public void addLabel()
            {
                
                for (int i = 0; i < array.Length; i++)
                {
                    Label lbl = new Label();
                    lbl.Text = array[i] + "\n";
                    lbl.AutoSize = true;
                    flowLayoutPanel1.Controls.Add(lbl);
                    flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
                }
            }
