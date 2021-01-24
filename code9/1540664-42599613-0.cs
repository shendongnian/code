    DateTime startDate = (DateTime)dtpStartDate.SelectedDate;
    DateTime endDate = (DateTime)dtpEndDate.SelectedDate;
    
      if (startDate != null && endDate != null)
      {
          while (startDate < endDate)
          {
              DataGridTextColumn newColumn = new DataGridTextColumn();
              newColumn.Header = startDate.ToShortDateString();
    
              dgTemplate.Columns.Add(newColumn);
    
              startDate = startDate.AddDays(1);
          }
      }
