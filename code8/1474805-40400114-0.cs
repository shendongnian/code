    [HttpPost]
    public void SaveData(string recordID, string GenAddress1, string GenAddress2, string GenAddress3, string GenCity,
        string GenPostCode, string GenPhoneNo, string GenFaxNo, DateTime? TodaysDate, DateTime? GenDeactivationDate)
    {
        var db = new MYDBEntities();
        db.WebForms_MyTable.Add(new WebForms_MyTable()
        {
           RecordID = recordID,
           AddressLine1 = GenAddress1,
           AddressLine2 = GenAddress2,
           AddressLine3 = GenAddress3,
           City = GenCity,
           Postcode = GenPostCode,
           PhoneNumber = GenPhoneNo,
           FaxNumber = GenFaxNo,
           ActivationDate = TodaysDate,
           DeactivationDate = GenDeactivationDate
        });
