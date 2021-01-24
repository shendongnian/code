    double minSpeed = double.MaxValue;
    double maxSpeed = 0.0;
    double averageCounter = 0.0;
    for(int x = 0; x < dataGridView1.Rows.Count; x++)
    {
        double value;
        if(double.TryParse(dataGridView1.Rows.Cells[2].Value, out value))
        {
            if(value < minSpeed) minSpeed = value;
            if(value > maxSpeed) maxSpeed = value;
            averageCounter += value;
        }
    }
    double average = averageCounter / dataGridView1.Rows.Count;
