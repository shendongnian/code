     public List<string> ChildPath(string ChildObject, List<string> ParentNameList, string AssembleyPath, string NameSpace, List<string> TraversedNodes)
        {
            Type ChildType = Type.GetType(NameSpace + ChildObject + AssembleyPath);
            List<string> Properties = ChildType.GetProperties().Where(x => x.PropertyType.IsClass && x.PropertyType.Assembly.GetName().Name != "mscorlib").Select(x => x.Name).ToList();
            ParentNameList.Add(ConfigurationManager.AppSettings[ChildObject].ToString());           
           // List<string> Properties = ConfigurationManager.AppSettings["Child_" + ChildObject].ToString().Split(',').ToList();
            int MaxIndex = 0;
            ChildObject = null;
            foreach (string item in Properties)
            {
                int PresIndex = TraversedNodes.IndexOf(item);
                if (MaxIndex <= PresIndex)
                {
                    MaxIndex = PresIndex;
                    ChildObject = item;
                }
            }
            if (ChildObject != null)
                PathTravarse(ChildObject, ParentNameList, AssembleyPath, NameSpace, TraversedNodes);
            return ParentNameList;
        }  
    public object GetLastChild(object DataObject, List<string> Path)
        {
            object Destination = DataObject;
            int Count = Path.Count;
            for (int i = 0; i < Count; i++)
            {
                PropertyInfo ChildProperty = Destination.GetType().GetProperty(Path[i]);
                Destination = ChildProperty.GetValue(Destination, null);
                Destination = ((IList)Destination)[((IList)Destination).Count - 1];               
            }
            
            return Destination;
        }
             public object CreateChildInstance(object DataObject, List<string> Path, string ChildName,string AssembleyPath,string NameSpace)
        {
            object Destination = DataObject;
            int Count = Path.Count - 1;
            for (int i = 0; i < Count; i++)
            {
                PropertyInfo ChildProperty = Destination.GetType().GetProperty(Path[i]);
                Destination = ((IList)ChildProperty.GetValue(Destination, null));
                Destination = ((IList)Destination)[((IList)Destination).Count - 1];
            }
            PropertyInfo FinalChild = Destination.GetType().GetProperty(Path[Count]);
            Destination = FinalChild.GetValue(Destination, null);
            Type InstanceType = Type.GetType(NameSpace + ChildName + AssembleyPath);
            Destination.GetType().GetMethod("Add").Invoke(Destination, new[] { Activator.CreateInstance(InstanceType) });
            return DataObject;
        }
