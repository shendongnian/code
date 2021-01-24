    //Retain previous row count
            int previousLength = namesTable.Rows.Count;
            //Work inside a for loop so you can manipulate the rows collection.
            for (int i = 0; i < previousLength; i++)
            {
                //First, get your split values.
                string[] vals = namesTable.Rows[i][0].ToString().Split(',');
                //Add a  new row for each item parsed from value string
                foreach (string s in vals)
                {
                    DataRow newRow = namesTable.NewRow();
                    newRow[0] = namesTable.Rows[i].ToString();
                    newRow[1] = s;
                    namesTable.Rows.Add(newRow);
                }
                //Remove all records from previous length and below. 
                for (int j = 0; j < previousLength; j++)
                {
                    namesTable.Rows.RemoveAt(j);
                }                
            }
