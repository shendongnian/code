                 var sLines = File.ReadAllLines("//dnc/WaterJet/MTI-WJ/" +   cboPartProgram.Text)
            .Where(s => !s.StartsWith("'") && s.Contains("S"))
            .Select(s => new
            {
                SValue = Regex.Match(s, "(?<=S)[\\d.]*").Value
            })
            .ToArray();
        foreach (var lines in sLines)
        {
            double sTime = double.Parse(lines.SValue);
             foreach (WjDwellOffsets offset in dwellTimes)
            {
                origionalDwellOffsets.Add(offset.dwellOffset);
                dgvDwellTimes.Rows.Add(new object[] { offset.positionId, sTime,      offset.dwellOffset, 0, offset.dwellOffset, "Update", (offset.dateTime > new DateTime(1900, 1, 1)) ? offset.dateTime.ToString() : "" });
                DataGridViewDisableButtonCell btnCell = ((DataGridViewDisableButtonCell)dgvDwellTimes.Rows[dgvDwellTimes.Rows.Count - 1].Cells[5]);
                
            }
        }
             btnCell.Enabled = false;
