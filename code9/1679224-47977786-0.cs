    		private void WriteDataBase() {
    			string filePath = Application.persistentDataPath + "/" + "Martyr.db";
    			string disPath;
    			if (File.Exists(filePath)) {
    				File.Delete(filePath);
    			}
    
    			disPath = System.IO.Path.Combine(Application.streamingAssetsPath, "Martyr.db");
    			WWW loadDB;
    #if UNITY_ANDROID
                {
                    loadDB = new WWW(disPath);
                }
    
    #if UNITY_EDITOR
                {
                    loadDB = new WWW("file://" + Application.streamingAssetsPath + "/Martyr.db");
                }
    #else
                {loadDB=new WWW(dispath);}
    #endif
    #endif
    			while (!loadDB.isDone) {
    			}
    			File.WriteAllBytes(filePath, loadDB.bytes);
    		}
