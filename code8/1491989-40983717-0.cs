                // Name 
                String nameSelection = ContactsContract.Data.InterfaceConsts.RawContactId + " = ? AND " 
                                       + ContactsContract.Data.InterfaceConsts.Mimetype + " = ? ";
                String[] nameSelectionArgs = {
                    _Contact.DataId.ToString(),
                    ContactsContract.CommonDataKinds.StructuredName.ContentItemType
                };
                ContentProviderOperation.Builder builder = ContentProviderOperation.NewUpdate(ContactsContract.Data.ContentUri);
                builder.WithSelection(nameSelection, nameSelectionArgs);
                builder.WithValue(ContactsContract.CommonDataKinds.StructuredName.GivenName, _Contact.FirstName);
                builder.WithValue(ContactsContract.CommonDataKinds.StructuredName.FamilyName, _Contact.LastName);
                ops.Add(builder.Build());
                // Phone
                String phoneSelection = ContactsContract.Data.InterfaceConsts.RawContactId + " = ? AND " 
                                        + ContactsContract.Data.InterfaceConsts.Mimetype + " = ? ";
                String[] phoneelectionArgs = {
                    _Contact.DataId.ToString(),
                    ContactsContract.CommonDataKinds.Phone.ContentItemType
                };
                builder = ContentProviderOperation.NewUpdate(ContactsContract.Data.ContentUri);
                builder.WithSelection(phoneSelection, phoneelectionArgs);
                builder.WithValue(ContactsContract.CommonDataKinds.Phone.Number, _Contact.Phone);
                ops.Add(builder.Build());
                // Email
                String emailSelection = ContactsContract.Data.InterfaceConsts.RawContactId + " = ? AND "
                                 + ContactsContract.Data.InterfaceConsts.Mimetype + " = ? ";
                String[] emailSelectionArgs = {
                    _Contact.DataId.ToString(),
                    ContactsContract.CommonDataKinds.Email.ContentItemType
                };
                builder = ContentProviderOperation.NewUpdate(ContactsContract.Data.ContentUri);
                builder.WithSelection(emailSelection, emailSelectionArgs);
                builder.WithValue(ContactsContract.CommonDataKinds.Email.InterfaceConsts.Data, _Contact.Email);
                ops.Add(builder.Build());
                // Update the contact
                ContentProviderResult[] result;
                try
                {
                    result = ContentResolver.ApplyBatch(ContactsContract.Authority, ops);
                }
                catch { }
