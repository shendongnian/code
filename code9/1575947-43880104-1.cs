    //Work inside a for loop so you can manipulate the rows collection.
            for (int i = 0; i < previousLength; i++)
            {
                //First, get your split values.
                string[] vals = namesTable.Rows[i][0].ToString().Split(',');
                //only operate on rows that were split into multiples.
                if (vals.Length > 1)
                {
                    //Add a  new row for each item parsed from value string
                    foreach (string s in vals)
                    {
                        DataRow newRow = namesTable.NewRow();
                        newRow[0] = namesTable.Rows[i].ToString();
                        newRow[1] = s;
                        namesTable.Rows.Add(newRow);
                    }
                }
            }
            //Remove old rows
            for (int i = 0; i < previousLength; i++)
            {
                namesTable.Rows.RemoveAt(i);
            }
