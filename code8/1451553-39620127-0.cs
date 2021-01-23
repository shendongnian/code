        public IEnumerator LoadPNG(string _path)
        {
            textureList = new Dictionary<int, Texture2D>();
            string[] filePaths = Directory.GetFiles(_path);
            foreach (string fileDir in filePaths)
            {
                using (WWW www = new WWW("file://" + Path.GetFullPath(fileDir)))
                {
                    yield return www;
                    Texture2D texture = Texture2D.whiteTexture;
                    www.LoadImageIntoTexture(texture);
                    textureList.Add(texture);
                }
            }
        }
