       // compute FechaJornada then...
       if(FechaJornada < e.Day.Date)
       {
          int rem = (e.Day.Date - FechaJornada).Days % 10;
          if (rem >= 1 && rem <= 8)
              e.Cell.BackColor = System.Drawing.Color.DarkGreen;
          else
              e.Cell.BackColor = System.Drawing.Color.DarkOrange;
       }
       else
          e.Cell.BackColor = System.Drawing.Color.White;
