    foreach (var item in Pirs)
        {
            byte[] data
            if (Pirs.IndexOf(item) == Pirs.Count - 2)
            {                
                data = Convert.FromBase64String(item.dataFrame.ToString());
                binModel.status = Convert.ToString(Encoding.UTF8.GetString(data).Substring(4));
            }  
            PIRDetailsViewModel binModel = new PIRDetailsViewModel();
            binModel.deviceid = deviceID;
                                   
            binModel.UpdatedTime = TimeZoneInfo.ConvertTimeFromUtc(item.timestamp, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")).ToString();
            model.Add(binModel);    
        }
