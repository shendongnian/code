       private void LoadDynamicResource(String sStyle)
        {
            FileInfo fi1 = new FileInfo(sStyle);
            if(fi1.Exists)
            {
            ResourceDictionary dic = new ResourceDictionary { Source = new Uri(sStyle, UriKind.RelativeOrAbsolute) };
            Resources.MergedDictionaries.Clear();
            Resources.MergedDictionaries.Add(dic);
            }
        }
