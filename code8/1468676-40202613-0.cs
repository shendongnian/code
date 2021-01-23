    using (var db = new DbEntities())
    {
        var recordsToAdd = new List<User>();
    
        var userIdSet = new HashSet<string>();
        var serialNumberExistsInfo = new Dictionary<string, bool>();
    
        for (var row = 2; row <= lastRow; row++)
        {
            var newRecord = new User
            {
                Id = Int32.Parse(worksheet.Cells[idColumn + row].Value.ToNullSafeString()),
                FirstName = worksheet.Cells[firstNameColumn + row].Value.ToNullSafeString(),
                LastName = worksheet.Cells[lastNameColumn + row].Value.ToNullSafeString(),
                SerialNumber = worksheet.Cells[serialNumber + row].Value.ToNullSafeString()
            };
    
            bool exists = !userIdSet.Add(newRecord.Id) || db.User.Any(u => u.Id == newRecord.Id);
            if (!exists)
            {
                bool isSerialNumberExist;
                if (!serialNumberExistsInfo.TryGetValue(newRecord.SerialNumber, out isSerialNumberExist))
                    serialNumberExistsInfo.Add(newRecord.SerialNumber, isSerialNumberExist = 
                        db.SerialNumbers.Any(u => u.SerialNumber == newRecord.SerialNumber));
                if (isSerialNumberExist)
                {
                    recordsToAdd.Add(newRecord);              
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
        }
    
        db.User.AddRange(recordsToAdd);
        db.SaveChanges();
    } 
