        public class VersionData
        {
            private static List<VersionData> VersionDatas { get; set; } = new List<VersionData>()
            {
                new VersionData( "OldversionToInstall", new [] {"windows10(pro)", "windows10(pro)(education)" }.ToList(), "windows81(pro)" ),
                new VersionData( "OldversionToInstall", new [] {"windows10(enterprise)", "windows10(enterpise)(lstb)" }.ToList(), "windows81(enterprise)" )
            };
    
            public string Action { get; set; } = "";
            public List<string> CurrentVersions { get; set; } = new List<string>();
            public string OldVersion { get; set; } = "";
            
            public VersionData(string action, List<string> currentVersions, string oldVersion)
            {
                Action = action;
                CurrentVersions = currentVersions;
                OldVersion = oldVersion;
            }
    
            public static string GetOldVersion(string action, string currentVersion)
            {
                return VersionDatas.FirstOrDefault(o => o.Action == action && o.CurrentVersions.Any(x => x == currentVersion)).OldVersion;
            }
        }
