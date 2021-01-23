        bool exists = userDbIds.Contains(newRecord.Id) || recordsToAdd.ContainsKey(newRecord.Id);
        if (!exists)
        {
            bool isSerialNumberExist = serialNumbers.Contains(newRecord.SerialNumber);
            if (isSerialNumberExist)
            {
                recordsToAdd[newRecord.Id] = newRecord;
            }
            else
            {
                resultMessages.Add(string.Format("SerialNumber doesn't exist"));
            }
        }
        else
        {
            resultMessages.Add(string.Format("Record already exist"));
        }
 
