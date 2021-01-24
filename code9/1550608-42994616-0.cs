    var rem = (n - FechaJornada) % 10;
    if (rem >= 1 && rem <= 8)
      e.Cell.BackColor = System.Drawing.Color.DarkGreen;
    else
      e.Cell.BackColor = System.Drawing.Color.DarkOrange;
