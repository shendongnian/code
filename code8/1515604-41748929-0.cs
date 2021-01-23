    using System.Collections.ObjectModel;
    public class MyClass
    {
        private ObservableCollection<int> _integerList;
        //  Do not make this a ref parameter, it's a reference already
        public MyClass(ObservableCollection<int> intList)
        {
            _integerList = intList;
            _integerList.CollectionChanged += _integerList_CollectionChanged;
        }
        private void _integerList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //  Do stuff here in response to changed values in the list. 
            //  Now back to the reference thing again: int is immutable.
            //  You can't change it, you can only replace it with another 
            //  int. This event will be raised when you do that. 
            //
            //  If the objects in the ObservableCollection are class 
            //  instances rather than ints, they're mutable. You can 
            //  change their properties without replacing them. 
            //  ObservableCollection cannot know when that happens, so 
            //  it can't tell you. 
            //
            //  In that case, you'd need the class to implement 
            //  INotifyPropertyChanged. That's a different can of worms, 
            //  but it's a manageable one. 
        }
    }
...
    ObservableCollection<int> ints = new ObservableCollection<int>();
    MyClass myNewClass;
    var r = new Random();
    for (int i = 0; i < 10; i++)
    {
        ints.Add(r.Next(0, 100));
    }
    myNewClass = new MyClass(ints);
