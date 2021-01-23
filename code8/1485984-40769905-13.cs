       List<List<string>> data =new List<List<string>>();
            List<DeviceIndex> deviceIndex = new List<DeviceIndex>();
            DeviceIndex item = new DeviceIndex();
            item.Id = 111;
            item.AssetTag = "Tag";
            item.LeaseEndDate = DateTime.Now;
            item.Type = "Type";
            item.OperatingSystem = "OS";
            item.Model = "Model";
            deviceIndex.Add(item);
            deviceIndex.Add(item);
            foreach (var device in deviceIndex)
            {
                
                data.Add(new List<string>(new string[] { device.Id.ToString(), device.AssetTag, device.AssetTag, device.OperatingSystem }));
            }
            
           var json =  JsonConvert.SerializeObject(new {data= data });
