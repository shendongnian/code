    foreach (var line in File.ReadLines(_path))
    {
        var split = line.Split('|');
        var key = split[0];
        var value = split;
            var recordType = value[0];
            switch (recordType)
            {
                case "CDI":
                    var cdiRecord = ParseCdi(value);
                    if (!data.ContainsKey(key))
                    {
                        data.Add(key, new DataRecord
                        {
                            Id = key, CdiRecords = new List<CdiRecord>() {  cdiRecord }
                        });
                    }
                    else
                    {
                        data[key].CdiRecords.Add(cdiRecord);
                    }
                    break;
                case "CEX015":
                    var cexRecord = ParseCex(value);
                    if (!data.ContainsKey(key))
                    {
                        data.Add(key, new DataRecord
                        {
                            Id = key,
                            CexRecords = new List<Cex015Record>() { cexRecord }
                        });
                    }
                    else
                    {
                        data[key].CexRecords.Add(cexRecord);
                    }
                    break;
                case "CPH":
                    CphRecord cphRecord = ParseCph(value);
                    if (!data.ContainsKey(key))
                    {
                        data.Add(key, new DataRecord
                        {
                            Id = key,
                            CphRecords = new List<CphRecord>() { cphRecord }
                        });
                    }
                    else
                    {
                        data[key].CphRecords.Add(cphRecord);
                    }
                    break;
            }
    };
