    if (data.ContainsKey("albumName") && data["albumName"] != null)
     {
       //Assign specific data to type dynamic by deserialising the data
       dynamic arryAlbumName = JsonConvert.DeserializeObject(data["albumName"].ToString());
       if (arryAlbumName != null && arryAlbumName.Count > 0)
       {
        for (int count = 0; count < arryAlbumName.Count; count++)
        {
          if (count == 0)
          {
            ArrayList albumName = new ArrayList();
            //Check for data exists and update the array value to arlData[]
            if (!string.IsNullOrEmpty(arryAlbumName[count].ToString()))
            {
                albumName.Add(arryAlbumName[count]);
                data.Remove("albumName");
                data.Add("albumName", albumName);
                arlData[iterator] = data;
             }
            }
          } 
        }
      } 
