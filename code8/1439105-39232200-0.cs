        private void SetTimeToGPS(DateTime UTCtime)
        {
            if (m_SetTime)
            {
                // Get the local time zone and a base Coordinated Universal 
                // Time (UTC).
                TimeZone localZone = TimeZone.CurrentTimeZone;
                DateTime baseUTC = UTCtime; // new DateTime(2000, 1, 1);
                System.Diagnostics.Debug.WriteLine("\nLocal time: {0}\n",
                    localZone.StandardName);
                // Calculate the local time and UTC offset.
                DateTime localTime = localZone.ToLocalTime(baseUTC);
                TimeSpan localOffset =
                    localZone.GetUtcOffset(localTime);
                System.Diagnostics.Debug.WriteLine(string.Format("{0,-20:yyyy-MM-dd HH:mm}" +
                    "{1,-20:yyyy-MM-dd HH:mm}{2,-12}{3}",
                    baseUTC, localTime, localOffset,
                    localZone.IsDaylightSavingTime(localTime)));
                //adjust the clock
                //localTime += localOffset;
                PInvokeLibrary.SystemTimeLib.SetTime(localTime);
                m_SetTime = false;
            }
        }
