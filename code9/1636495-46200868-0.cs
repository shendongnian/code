     private void btnCalculate_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DGV_Hidden.Rows)
            {
                FileInfo info = new FileInfo();
                {
                    var lines = File.ReadAllLines(row.Cells["colfilelocation"].Value.ToString());
                    var data = lines.Where(line => (!line.Contains(Data_Start_Point_Identifier) && !line.Contains(FSD__Line_Identifier) && !line.EndsWith("0.00"))).ToList();
    
                    if (data.Count > 1)
                    {
                        var line = data[0];
                        var firstsplit = data[1].Split(splitter);
                        info.startvalue = Convert.ToDouble(firstsplit[0]);
                        var secondsplit = data[data.Count - 1].Split(splitter);
                        info.endvalue = Convert.ToDouble(secondsplit[0]);
                    }
                    info.finalnum = info.startvalue - info.endvalue;
                }
             //set your value here
                DGV.Rows[row .index].Cells["colfiledata"].Value = info.finalnum;
            }
        }
