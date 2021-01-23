        public static TargetFrameworkAttribute GetTargetFrameworkFromCsproj()
        {
            XmlNode targetFrameworkNode = CsprojDoc.SelectSingleNode("//x:TargetFrameworkVersion", Nsmgr);
            return new TargetFrameworkAttribute($".NETFramework, Version={targetFrameworkNode.InnerXml}");
        }
    
