                 byte[] rawData = byte[];
             string tempFile = Application.persistentDataPath + "/bytes.mp3";
             System.IO.File.WriteAllBytes(tempFile, rawData);
             
             WWW loader = new WWW("file://" + tempFile);
             yield return loader;
             if(!System.String.IsNullOrEmpty(loader.error))
                 Debug.LogError(loader.error);
             
             AudioClip s1 = loader.GetAudioClip(false, false, AudioType.MPEG);
                         //or
             AudioClip s2 = loader.audioClip;
