    private void Form3_Load(object sender, EventArgs e)
                {
                    Label[] nmr = new Label[10];
                    for (int i = 0; i < 10; i++)
                    {
                        nmr[i] = new Label();
                        nmr[i].Text = "label " + i;
                        nmr[i].Location = new Point(0, 25 * i);
                        this.Controls.Add(nmr[i]);
                    }
                    this.Height = this.Height + (25 * nmr.Count());
                }
