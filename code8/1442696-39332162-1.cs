    public void PutControls(TabPage tb) {
                Button btn = new Button();
                btn.Text = "testButton";
                btn.Height = 20;
                btn.Width = 150;
                btn.Location = new Point(4, 26);
                TextBox txt = new TextBox();
                txt.Text = "test";
                txt.Location =new Point(34, 126);
                tb.Controls.Add(btn);
                tb.Controls.Add(txt);
            }
