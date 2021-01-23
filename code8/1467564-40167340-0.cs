            string data = Encoding.UTF8.GetString(eventData.GetBytes());
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateParseHandling = DateParseHandling.DateTimeOffset,
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
            };
            List<ObjWithDateTimeOffset> eAcqs = JsonConvert.DeserializeObject<List<ObjWithDateTimeOffset>>(data, jsonSerializerSettings);
            List<ObjWithDateTime> gAcqs = new List<ObjWithDateTime>();
            foreach(ObjWithDateTimeOffset eAcq in eAcqs)
            {
                ObjWithDateTime gAcq = new ObjWithDateTime()
                {
                    AcquisitionType = eAcq.AcquisitionType,
                    Value = eAcq.Value,
                    DateAcquisition = eAcq.DateAcquisition.DateTime,
                };
                gAcqs.Add(gAcq);
            }
            return gAcqs;
