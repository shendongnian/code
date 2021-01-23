    JObject o = new JObject();
    foreach (MotorModel mm in allData) {
        foreach (MotorDataModel mdm : mm.MotorData()) {
            string key = mdm.TimeStamp.ToString(); // Or do your own format
            o[key][mm.MotorName + ":kW"] = mdm.MotorKw;
            o[key][mm.MotorName + ":Speed"] = mdm.MotorSpeed;
            o[key][mm.MotorName + ":TEmp"] = mdm.MotorTemp;
        }
    }
