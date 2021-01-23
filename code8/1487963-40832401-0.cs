            string ctlName;
            Control[] matches;
            Control player, score;
            string[] lines = File.ReadAllLines(filePath);
            for(int i = 0; i < 5; i++)
            {
                player = null;
                ctlName = "txtPlayer" + (i + 1).ToString();
                matches = this.Controls.Find(ctlName, true);
                if (matches.Length > 0)
                {
                    player = matches[0];
                    player.Text = "";
                }
                score = null;
                ctlName = "lblPlayer" + (i + 1).ToString() + "Points";
                matches = this.Controls.Find(ctlName, true);
                if (matches.Length > 0)
                {
                    score = matches[0];
                    score.Text = "";
                }
                if (i < lines.GetUpperBound(0))
                {
                    string[] parts = lines[i].Split(",".ToCharArray());
                    if (parts.Length == 2)
                    {
                        string[] nameParts = parts[0].Split(":".ToCharArray());
                        if (nameParts.Length == 2)
                        {
                            if (player != null)
                            {
                                player.Text = nameParts[1].Trim();
                            }
                        }
                        string[] scoreParts = parts[1].Split(":".ToCharArray());
                        if (scoreParts.Length == 2)
                        {
                            if (score != null)
                            {
                                score.Text = scoreParts[1].Trim();
                            }
                        }
                    }
                }
            }
