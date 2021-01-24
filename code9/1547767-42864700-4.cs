    List<PIRDetail> Pirs = Newtonsoft.Json.JsonConvert.DeserializeObject <List<PIRDetail>>(responseString);
    var item = Pirs[Pirs.Count -2];
                    
    byte[] data = Convert.FromBase64String(item.dataFrame.ToString());
    PIRDetailsViewModel binModel = new PIRDetailsViewModel();
    binModel.deviceid = deviceID;
    binModel.status = Convert.ToString(Encoding.UTF8.GetString(data).Substring(4));                        
    binModel.UpdatedTime = TimeZoneInfo.ConvertTimeFromUtc(item.timestamp, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")).ToString();
    model.Add(binModel);
