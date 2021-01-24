            string profilePicUrl = await  _apiCaller.GetProfilePictureUrlAsync();
            using(var web = new WebClient())
            {
                byte[] picBytes = await web.DownloadDataTaskAsync(profilePicUrl);
                 
                // unity api here works because we are back in the main thread
                // as async returns you to the contex in which you started
                var profilePicTexture = new Texture2D(4, 4);
                profilePicTexture.LoadImage(picBytes);
                return profilePicTexture;
            }
