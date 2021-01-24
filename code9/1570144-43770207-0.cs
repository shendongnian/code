            List<string> table1List = new List<string>();
            for (int counter = 0; counter < 6; counter++)
            {
                while (reIterator < 7)
                {
                    string currentLabel = "LblRE" + reIterator + "R" + replicateIterator;
                    Label reLabel = this.Controls.Find(currentLabel, true).FirstOrDefault() as Label;
                    if (reLabel.Text != null)
                    {
                        table1List.Add(reLabel.Text);
                        reIterator = reIterator + 1;
                    }
                    else
                    {
                        table1List.Add(reLabel.Text = "");
                        reIterator = reIterator + 1;
                    }
                }
                //Builds next row
                if (reIterator == 7)
                {
                    replicateIterator = replicateIterator + 1;
                    reIterator = 1;
                }
            }
