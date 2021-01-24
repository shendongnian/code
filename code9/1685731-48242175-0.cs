    namespace Question48240657
    {
        public class MainViewModel
        {
            public List<object> Groups { get; set; }
    
            public List<Data> MainData { get; set; }
    
            public MainViewModel()
            {
                MainData = GetData();
                Groups = GetGroups(MainData);
            }
    
            private List<object> GetGroups(List<Data> mainData)
            {
                var groups = new List<object>()
                {
                    new Group1() { DataList = mainData.Where(x => x.GropuName == "Group1").ToList() },
                    new Group2() { DataList = mainData.Where(x => x.GropuName == "Group1").ToList() },
                    new Group3() { DataList = mainData.Where(x => x.GropuName == "Group1").ToList() },
                };
                return groups;
            }
    
            public List<Data> GetData()
            {
                var dataList = new List<Data>()
                {
                    new Data() { Name = "Data1", GropuName = "Group1" },
                    new Data() { Name = "Data2", GropuName = "Group1" },
                    new Data() { Name = "Data3", GropuName = "Group1" },
                    new Data() { Name = "Data4", GropuName = "Group2" },
                    new Data() { Name = "Data5", GropuName = "Group2" },
                    new Data() { Name = "Data6", GropuName = "Group2" },
                    new Data() { Name = "Data7", GropuName = "Group3" },
                    new Data() { Name = "Data8", GropuName = "Group3" },
                    new Data() { Name = "Data9", GropuName = "Group3" },
                };
                return dataList;
            }
        }
    
        #region Classes from directory "Model"
    
        public class Data
        {
            public string Name { get; set; }
    
            public string GropuName { get; set; }
        }
    
        public class Group1
        {
            public List<Data> DataList { get; set; }
        }
    
        public class Group2
        {
            public List<Data> DataList { get; set; }
        }
    
        public class Group3
        {
            public List<Data> DataList { get; set; }
        }
    
        #endregion
    }
