    int i = 0;
    TableRow TimeSLotRow = new TableRow();
    foreach (AvailableTime resultTimeslot in AllTimeSlots)
    {
        
        TableCell TimeSlotCell = new TableCell();
        TimeSlotCell.Text = Convert.ToString(resultTimeslot.TimeSlot);
        TimeSLotRow.Cells.Add(TimeSlotCell);
        i++;
  
        if(i == 5)
        {
            
            Table1.Rows.Add(TimeSLotRow);
            TimeSLotRow = new TableRow();
            i = 0;
        }
    }
