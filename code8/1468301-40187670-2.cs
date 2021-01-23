    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load("schedule.xml");
    XmlElement root = xmlDoc.DocumentElement;  // Schedules
    int scheduleNumber = 0;
    foreach (XmlElement schedule in root.ChildNodes)
    {
        scheduleNumber++;
        StackPanel schedulePanel = new StackPanel { Orientation = Orientation.Horizontal };
        Label scheduleLabel = new Label { Content = "Schedule " + scheduleNumber.ToString() };
        schedulePanel.Children.Add(scheduleLabel);
        stkPan_display.Children.Add(schedulePanel);
        foreach (XmlElement course in schedule.ChildNodes)
        {
            StackPanel addPanel = new StackPanel { Orientation = Orientation.Horizontal };
            // all child elements of the Course element
            foreach (XmlElement child in course.ChildNodes)
            {
                Label lblChild = new Label();
                lblChild.Foreground = new SolidColorBrush(Colors.Black);
                lblChild.Content = child.InnerText;
                addPanel.Children.Add(lblChild);
            }
            stkPan_display.Children.Add(addPanel);
        }
    }
