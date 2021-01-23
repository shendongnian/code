       private void LoadDynamicResource(String sStyle)
        {
            FileInfo fi1 = new FileInfo(sStyle);
            if(fi1.Exists)
            {
                using (FileStream fs = new FileStream(sStyle, FileMode.Open))
                {
                   ResourceDictionary dic = (ResourceDictionary)XamlReader.Load(fs);
                   Resources.MergedDictionaries.Clear();
                   Resources.MergedDictionaries.Add(dic);
                }
            }
        }
