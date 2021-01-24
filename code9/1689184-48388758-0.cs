       foreach (Appointment a in appointments)
            {               
                if (a.LastModifiedTime >= Convert.ToDateTime(date))
                {
                    i++;
                    TAppointments app = new TAppointments(a.ICalUid.ToString(), a.Subject.ToString(), a.Start.ToString(), a.End.ToString(), a.LastModifiedTime.ToString());
                    currentApp = app;
                    tempList.Add(app);
                    found = true;
                }
            }
