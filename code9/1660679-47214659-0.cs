        IReadOnlyList<StorageFile> x = await ApplicationData.Current.LocalFolder.GetFilesAsync();
            int tempCt = x.Count;
            foreach (StorageFile file in x)
            {
                if (file.Name.ToString().Contains("csv"))
                {
                    sb.Append(file.Name + System.Environment.NewLine);
                }
            }
