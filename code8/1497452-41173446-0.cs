    double stime;
    
    for (int i = 0; i < sLines.Count(); i++)
    {
        sTime = double.Parse(sLines[i].SValue); // Or sLines.ElementAt(i)
    
        origionalDwellOffsets.Add(dwellTimes[i].dwellOffset); // Or dwellOffset.ElementAt(i)
        dgvDwellTimes.Rows.Add(new object[] { dwellTimes[i].positionId, sTime, dwellTimes[i].dwellOffset, 0, dwellTimes[i].dwellOffset, "Update", (dwellTimes[i].dateTime > new     DateTime(1900, 1, 1)) ? dwellTimes[i].dateTime.ToString() : "" });
        DataGridViewDisableButtonCell btnCell = ((DataGridViewDisableButtonCell)dgvDwellTimes.Rows[dgvDwellTimes.Rows.Count - 1].Cells[5]);     
    }
