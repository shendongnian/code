    public void action()
    {
        RadDesktopAlert Alert;
        for (int i = 0; i < radGridView4.Rows.Count; i++)
        {
            DateTime executionTime = Convert.ToDateTime(radGridView4.Rows[i].Cells[10].Value.ToString());
            if (DateTime.Now.Date == executionTime.Date && DateTime.Now.Hour == executionTime.Hour && DateTime.Now.Minute == executionTime.Minute)
            {
                Alert = new RadDesktopAlert();
                firma = radGridView4.Rows[i].Cells[2].Value.ToString();
                Alert.CaptionText = "Telefonmøde";
                Alert.ContentText = firma;
                Alert.Show();
                break; // This will prevent duplicate alarms
            }
        }
    }
