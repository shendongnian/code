     private async void btnSave_Click(object sender, RoutedEventArgs e)
     {
         var name = txtName.Text;
         var tel = txtTel.Text;
         ContactStore contactStore = await ContactStore.CreateOrOpenAsync(ContactStoreSystemAccessMode.ReadWrite, ContactStoreApplicationAccessMode.ReadOnly);
         ContactInformation contactInformation = new ContactInformation();
         contactInformation.DisplayName = name;
         var contactProps = await contactInformation.GetPropertiesAsync();
         contactProps.Add(KnownContactProperties.MobileTelephone, tel);
         StoredContact storedContact = new StoredContact(contactStore, contactInformation);
         await storedContact.SaveAsync();
     }
     private async void btnGet_Click(object sender, RoutedEventArgs e)
     {
         ContactStore contactStore = await ContactStore.CreateOrOpenAsync(ContactStoreSystemAccessMode.ReadWrite, ContactStoreApplicationAccessMode.ReadOnly);
         var result = contactStore.CreateContactQuery();
         var count = await result.GetContactCountAsync();
         var list = await result.GetContactsAsync();
         foreach (var item in list)
         {
             var properties = await item.GetPropertiesAsync();
             System.Diagnostics.Debug.WriteLine(item.DisplayName);                
             System.Diagnostics.Debug.WriteLine(properties[KnownContactProperties.MobileTelephone].ToString());
         }
     }
