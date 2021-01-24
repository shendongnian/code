        HourlyAlarm1.Properties.Settings.Default.halfHourSelected = true;
        HourlyAlarm1.Properties.Settings.Default.Save();
    or, as always, if you're gonna access them several times,
        using HourlyAlarm1.Properties;
        /** 
         * declare the namespace, the class, etc.
         */
        Settings.Default.halfHourSelected = true;
        Settings.Default.Save();
