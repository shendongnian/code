    double minSpeed = double.MaxValue;
    double maxSpeed = 0.0;
    double averageCounter = 0.0;
    for(int x = 0; x < dataGridView1.Rows.Count; x++)
    {
        double value;
        // If TryParse cannot convert the input it returns false and this
        // code will simply skip the row and continue with the next one.
        // Of course you can code an else condition and display an error
        // message referencing the invalid line (x)
        if(double.TryParse(dataGridView1.Rows[x].Cells[2].Value, out value))
        {
            if(value < minSpeed) minSpeed = value;
            if(value > maxSpeed) maxSpeed = value;
            averageCounter += value;
        }
    }
    double average = averageCounter / dataGridView1.Rows.Count;
