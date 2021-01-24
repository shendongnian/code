    var model = (from person in personel
                    where person.ID == id
                    select new PersonelWithContactListDto {
                        PersonelName = person.PersonelName,
                        PersonelLastname = person.PersonelSurname,
                        PersonelPrivateNo = person.PersonelPrivateNo,
                        Contacts = (from contact
                                    in person.Contacts
                                    join contactType in contactTypes
                                    on contact.ID equals contactType.ID
                                    select new ContactListDto {
                                        Value = contact.Value,
                                        ContactType = contactType.Value,
                                        ID = contact.ID
                                    }).ToList()
                    }).FirstOrDefault();
