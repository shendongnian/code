    public void Button3_Click(object sender, EventArgs e)
        {
            List<string> values = new List<string>();
            // Create a new instance of the Form2 class
            // Form2 goForm2 = new Form2();
            // Show the settings form
            // goForm2.Show();
            //string checkP = "p = ";
           // string removePE = checkP.Replace("P = ", "").Replace("F = ", "");
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    //prevent error occur coz , only execute the not null line
                    if(cell.Value != null)
                    {
                        string cellV = cell.Value.ToString();
                        //do operations with cell
                        if (!cellV.Contains("="))
                        {
                            continue;
                        }
                       else if (cellV.Contains("P = "))
                        {
                            cellV = cellV.Replace("P = ", "");
                        }
                        else if (cellV.Contains("F = n/a"))
                        {
                            cellV =cellV.Replace("F = n/a", "0");
                        }
                        else if (cellV.Contains("F = "))
                        {
                            cellV = cellV.Replace("F = ", "");
                        }
                        values.Add(cellV);
                        Console.WriteLine(cellV + "\n");
                    }
                }
            }
        }
