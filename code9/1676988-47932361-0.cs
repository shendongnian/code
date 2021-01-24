    dynamic registerSongObjs = new JObject();
    var songs = EntityDataAccess.GetSongsByAccountInfoID(accountInfo.AccountInfoID);
                        foreach (var item in songs)
                        {
                            registerSongObjs.Artist = accountInfo.DisplayName;
                            registerSongObjs.objectID = item.SongID;
                            songIndexHelper.PartialUpdateObject(registerSongObjs);
                        }
