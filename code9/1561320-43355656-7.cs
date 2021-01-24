    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Media;
    
    namespace Fruits.ViewModels
    {
        public class ViewModelBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(string name)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
            }
        }
    
        public class Fruit : ViewModelBase
        {
            public Fruit()
            {
            }
    
            public Fruit(string name, String clrString)
            {
                FruitName = name;
                //  Parse colors like so: (Color)ColorConverter.ConvertFromString(clrString);
                FruitColor = clrString;
            }
    
            public Fruit(string name, Color clr)
            {
                FruitName = name;
                FruitColor = clr.ToString();
            }
    
            private string _fruitname;
            public string FruitName
            {
                get
                {
                    return _fruitname;
                }
                set
                {
                    if (_fruitname != value)
                    {
                        _fruitname = value;
                        OnPropertyChanged("FruitName");
                    }
                }
            }
    
            private String _fruitcolor;
            public String FruitColor
            {
                get
                {
                    return _fruitcolor;
                }
                set
                {
                    if (_fruitcolor != value)
                    {
                        _fruitcolor = value;
                        OnPropertyChanged("FruitColor");
                    }
                }
            }
    
            private bool _selected;
            //  NOTE: I renamed this property
            public bool Selected
            {
                get
                {
                    return _selected;
                }
                set
                {
                    if (_selected != value)
                    {
                        _selected = value;
                        OnPropertyChanged("Selected");
                    }
                }
            }
        }
    
        #region MainViewModel Class
        public class MainViewModel : ViewModelBase
        {
            #region Add Methods
            public void AddNewFruit()
            {
                Fruits.Add(new Fruit(NewFruitName, NewFruitColor));
    
                NewFruitName = "";
                NewFruitColor = "";
            }
    
            public void AddNewFruit(string name, string color)
            {
                Fruits.Add(new Fruit(name, color));
            }
    
            public void AddNewFruit(string name, Color color)
            {
                Fruits.Add(new Fruit(name, color));
            }
            #endregion Add Methods
    
            #region NewFruitName Property
            private String _newFruitName = default(String);
            public String NewFruitName
            {
                get { return _newFruitName; }
                set
                {
                    if (value != _newFruitName)
                    {
                        _newFruitName = value;
                        OnPropertyChanged("NewFruitName");
                    }
                }
            }
            #endregion NewFruitName Property
    
            #region NewFruitColor Property
            private String _newFruitColor = default(String);
            public String NewFruitColor
            {
                get { return _newFruitColor; }
                set
                {
                    if (value != _newFruitColor)
                    {
                        _newFruitColor = value;
                        OnPropertyChanged("NewFruitColor");
                    }
                }
            }
            #endregion NewFruitColor Property
    
            #region Fruits Property
            private ObservableCollection<Fruit> _fruits = new ObservableCollection<Fruit>();
            public ObservableCollection<Fruit> Fruits
            {
                get { return _fruits; }
                private set
                {
                    if (value != _fruits)
                    {
                        _fruits = value;
                        OnPropertyChanged("Fruits");
                    }
                }
            }
            #endregion Fruits Property
        }
        #endregion MainViewModel Class
    }
