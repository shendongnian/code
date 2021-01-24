    private void Form1_Load()
    {
                for (var i = 0; i < 20; i++)
                {
                    Label TemporaryLabel = new Label();
                    TemporaryLabel.AutoSize = false;
                    TemporaryLabel.Size = new Size(flowLayoutPanel1.Width, 50);
                    TemporaryLabel.Text = "This is a ______ message";
                    string SubText = "";
                    var StartIndex = TemporaryLabel.Text.IndexOf('_');
                    var EndIndex = TemporaryLabel.Text.LastIndexOf('_');
                    if ((StartIndex != -1 && EndIndex != -1) && EndIndex > StartIndex)
                    {
                        string SubString = TemporaryLabel.Text.Substring(StartIndex, EndIndex - StartIndex);
                        SizeF nSize = Measure(SubString);
                        TextBox TemporaryBox = new TextBox();
                        TemporaryBox.Size = new Size((int)nSize.Width, 50);
                        TemporaryLabel.Controls.Add(TemporaryBox);
                        TemporaryBox.Location = new Point(TemporaryBox.Location.X + (int)Measure(TemporaryLabel.Text.Substring(0, StartIndex - 2)).Width, TemporaryBox.Location.Y);
                    }
                    else continue;
                    flowLayoutPanel1.Controls.Add(TemporaryLabel);
                }
    } 
