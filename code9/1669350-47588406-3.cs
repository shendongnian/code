     Contact newContact = new Contact();
     newContact.Name = "Susan";
     newContact.Email = "susan@example.com";
     column.ContactOptions = new Contact[] { newContact };
     ss.SheetResources.ColumnResources.UpdateColumn(sheetId, column);
