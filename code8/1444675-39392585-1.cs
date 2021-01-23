    int seconds = totalSeconds % 60;
    int totalMinutes = totalSeconds / 60;
    int minutes = totalMinutes % 60;
    int totalHours = totalMinutes / 60;
    int hours = totalHours % 24;
    int totalDays = totalHours / 24;
    StringBuilder builder = new StringBuilder;
    if (totalDays > 0)
    {
        builder.Append(totalDays + " Days ");
    }
    if (totalHours > 0)
    {
        builder.Append(hours + " Hours ");
    }
    if (totalMinutes > 0)
    {
        builder.Append(minutes + " Minutes ");
    }
    builder.Append(seconds + " Seconds");
    MessageBox.Show(builder.ToString());
