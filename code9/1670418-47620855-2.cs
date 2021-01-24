    using MVVMExample.Utils;
    
    namespace MVVMExample.ViewModels
    {
        public class TableViewPageVM : BindableBase
        {
            //Simple text to bind to the TableSection Title property
            private string tableSectionTitle;
            public string TableSectionTitle { get { return tableSectionTitle; } set { SetProperty(ref tableSectionTitle, value); } }
    
            //Property that will hold our struValues instance. The TextCell "Text" Property will be bound to the A property of this instance.
            //The A property exposes the value of the actual "a" property of the facades struct instance
            private struValuesFacade _struValues;
            public struValuesFacade StruValues { get { return _struValues; } set { SetProperty(ref _struValues, value); } }
            
            public TableViewPageVM()
            {
                TableSectionTitle = "Cool Struct Section"; //Set the title text
                StruValues = new struValuesFacade(123);     //Create an instance of our facade
            }
    
            /// <summary>
            /// A "facade" of the actual struct, that exposes the "a" property of the struct instance
            /// Also holds the instances of the struct
            /// </summary>
            public class struValuesFacade : BindableBase
            {
                struValues origin;
                public int A
                {
                    get { return origin.a; }
                    set
                    {
                        SetProperty(ref origin.a, value);
                    }
                }
    
                public struValuesFacade(int value)
                {
                    origin = new struValues() { a = value };
                }
            }
    
            /// <summary>
            /// Your beloved struct
            /// </summary>
            struct struValues
            {
                public int a;
            }
        }
    }
