    var timeTable = new TimeTable(){Company= "12366", 
                                    INN = "12366",
                                    StartDay = "8/14/2017T14.48");
    
    var response = client.PostAsync("/StartWorkingDays",
                                new StringContent(
                                    JsonConvert.SerializeObject(timeTable),
                                                    Encoding.UTF8, "application/json")).Result;
