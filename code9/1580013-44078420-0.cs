    private async void updateData<T>(Realm realm, IList<T> dataList) where T : RealmObject, IMaster, new()
    {
       await realm.WriteAsync(tempRealm =>
       {
           foreach (IMaster data in dataList)
           {
               IMaster dbData = null;
               if (data.getStatus().Equals("CREATED"))
               {
                   // Problem is here at tempRealm.All<Contact>() i am not able to generlize the fetching of objects
                   dbData = tempRealm.Find<T>(data.getmId());
                   //you need to put these properties in IMaster (id, syncInfo)
                   dbData.id = data.id;
                   dbData.syncInfo.isSync = SyncStatus.SYNCED;
               }
           }
       });
    }
