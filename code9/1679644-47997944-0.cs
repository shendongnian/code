            DateTime start = new DateTime(
                            dtpDateStart.Value.Year,
                            dtpDateStart.Value.Month,
                            dtpDateStart.Value.Day,
                            dtpTimeStart.Value.Hour,
                            dtpTimeStart.Value.Minute,
                            0);
            DateTime end = new DateTime(
                dtpDateEnd.Value.Year,
                dtpDateEnd.Value.Month,
                dtpDateEnd.Value.Day,
                dtpTimeEnd.Value.Hour,
                dtpTimeEnd.Value.Minute,
                0);
            TimeSpan subtotal = end - start;
            decimal decSubtotalMinutes = Convert.ToDecimal(subtotal.TotalMinutes);
            decSubtotalMinutes = decSubtotalMinutes / 60;
            decSubtotalMinutes = (Math.Floor(decSubtotalMinutes * 10) / 10);
