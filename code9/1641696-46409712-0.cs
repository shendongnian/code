    using System;
    using System.Reflection;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                EFTypeData itemData = GetItemData();
                var asmName = Assembly.GetExecutingAssembly().GetName().Name;
                var type = Type.GetType($"ConsoleApplication1.{itemData.TypeName}, {asmName}");
                var instance = Activator.CreateInstance(type);
                var item = new Item<Object>()
                {
                    ItemBase = instance 
                };
            }
            private static EFTypeData GetItemData()
            {
                return new EFTypeData() { TypeName = "ItemFile" };
            }
        }
        class EFTypeData
        {
            public string TypeName { get; set; }
        }
        class Item<T> where T: class
        {
            public T ItemBase { get; set; }
        }
        class ItemFile
        {
            public string FileName { get; set; }
        }
    }
