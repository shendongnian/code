       public class ChangingNameObject
        {
            public delegate void ObjectNameChange(string oldName, string newName);
            public event ObjectNameChange ObjectNameChanged;
            private string name;
            public string Name 
            { 
                get => name;
                set
                {
                    ObjectNameChanged?.Invoke(name, value);
                    name = value;
                }
            }
        }
    
        public class WatchingDictionary
        {
            private Dictionary<string, ChangingNameObject> content = new Dictionary<string, ChangingNameObject>();
    
            public void Add(ChangingNameObject item)
            {
                item.ObjectNameChanged += UpdatePosition;
                content[item.Name] = item;
            }
    
            public void Remove(ChangingNameObject item)
            {
                item.ObjectNameChanged -= UpdatePosition;
                content.Remove(item.Name);
            }
    
            private void UpdatePosition(string oldname, string newname)
            {
                var o = content[oldname];
                content.Remove(oldname);
                content.Add(newname, o);
            }
        }
