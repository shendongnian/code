    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Data;
    using System.Windows.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
            }
        }
        public class MainViewModel :  INotifyPropertyChanged
        {
            public static Product selectedProduct;
            static DataSet _ds = null;
            static Module sdb = new Module();
            ObservableCollection<Module> myModulesList { get; set; }
            static ICollectionView ModulesView = null;
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                //see : https://stackoverflow.com/questions/1315621/implementing-inotifypropertychanged-does-a-better-way-exist
            }
            private static void NotifyPropertyChanged(Product product)
            {
            }
            private void RefreshModulesByOrder()
            {
              
                myModulesList = new ObservableCollection<Module>(sdb.GetOrderModules().OrderBy(mod => mod.Address));
                ModulesView = CollectionViewSource.GetDefaultView(myModulesList);
                ModulesView.Filter = obj =>
                {
                    var Module = (Module)obj;
                    return selectedProduct != null && selectedProduct.ModelNumber == Module.ModelNumber;
                };
            }
            private static Product RefreshModules()
            {
                _ds = sdb.GetModules();
                _ds.Tables["Modules"].DefaultView.Sort = "Address";
                ModulesView = new ListCollectionView(_ds.Tables["Modules"].DefaultView)
                {
                    Filter = obj =>
                    {
                        var Module = obj as DataRowView;
                        return selectedProduct != null && selectedProduct.ModelNumber == (int)Module["ModelNumber"];
                    }
                };
                return null;
            }
            public ushort[] DatagridToArray()
            {
                return _ds.Tables["Modules"].AsEnumerable().Select(mod => mod.Field<UInt16>("ParamValue")).ToArray();
            }
            public static void RefreshProductList()
            {
            }
            public static void RefreshCommunication()
            {
            }
            public class Product
            {
                public int ModelNumber { get; set; }
                public Product SelectedProduct
                {
                    get { return selectedProduct; }
                    set
                    {
                        if (selectedProduct != value)
                        {
                            selectedProduct = value;
                            NotifyPropertyChanged(this);
                            RefreshProductList();
                            RefreshModules();
                            RefreshCommunication();
                        }
                    }
                }
            }
            public class Module
            {
                public int ModelNumber { get; set; }
                public int Address { get; set; }
                public DataSet GetModules()
                {
                    return new DataSet();
                }
                public List<Module> GetOrderModules()
                {
                    return new List<Module>();
                }
            }
        }
    }
