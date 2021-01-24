    int counter = 1;
    for(n = FechaJornada; n <= ultimo; n.AddDay(1))
    {
       int rem = counter % 10;
       if (rem >= 1 && rem <= 8)
           e.Cell.BackColor = System.Drawing.Color.DarkGreen;
       else
           e.Cell.BackColor = System.Drawing.Color.DarkOrange;
       counter++;
    }
