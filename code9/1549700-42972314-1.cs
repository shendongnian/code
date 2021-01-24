        var contactInfo = new ContactInfo()
        {
            ContactInfoId = 1, 
            Phones = new List<PhoneToCustomer>()
            {
                new PhoneToCustomer()
                {
                     Phone = new Phone(){CountryCode = "Code1", Extension = "Extension1"},
                },
                new PhoneToCustomer()
                {
                     Phone = new Phone(){CountryCode = "Code2", Extension = "Extension2"}
                }
            }
        };
        
    var contactInfoModel = AutoMapper.Mapper.Map<ContactInfoModel>(contactInfo);
        
    var contactInfoBack = AutoMapper.Mapper.Map<ContactInfo>(contactInfoModel); 
