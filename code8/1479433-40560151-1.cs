    var result = relatedContact.SelectMany(rc => rc.contacts.Select(pc => {pc})
                               .GroupJoin(fileContactIds, pc => pc.userclientcode,
                                          fc => fc.ContactId,new {pc,fc})
                               .SelectMany(
                                x => x.fc.DefaultIfEmpty()
                                (x,y) => new RelatedContactsDescription
                                {
                                   userclientcode = (y == null) ? "Default":x.pc.userclientcode,
                                .........(fill remaining as per original logic)
                                });
