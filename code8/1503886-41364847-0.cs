    var itemsToUpdate = from d1 in GetDevice1Arr()
                        join d2 in GetDevice2Arr()
                             on new { d1.DeviceName, d1.IP }
                             equals new { d2.DeviceName, IP = d2.DeviceIP }
                        select d1;
    
    foreach(var d1 in itemsToUpdate)
        d1.IsExist = true;
