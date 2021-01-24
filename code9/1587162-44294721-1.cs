     string AppPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string targetPath = Path.Combine(AppPath, @"Sources\Pictures\", FileNo);
            if (Directory.Exists(targetPath))
            {
                var ListPath = Directory.GetFiles(targetPath, "*.jpg", SearchOption.AllDirectories).ToList();
                List<ExplorerData> Items = new List<ExplorerData>();
                for (int i = 0; i < ListPath.Count; i++)
                {
                    var ImageName = Path.GetFileName(ListPath[i]);
                    Items.Add(new ExplorerData()
                    {
                        ID = i + 1,
                        Name = ImageName.Remove(ImageName.Length - 4, 4),
                        Icon = ListPath[i]
                    });
                }
                lvMaster.ItemsSource = Items;
            }
     public class ExplorerData
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public object Icon { get; set; }
        }
