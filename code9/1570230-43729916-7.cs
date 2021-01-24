        using GalaSoft.MvvmLight;
        using GalaSoft.MvvmLight.CommandWpf;
        using DataGridInUserControlDemo.Model;
        using System.Windows.Input;
        using System.Collections.ObjectModel;
        
        namespace DataGridInUserControlDemo.ViewModel
        {
            public class MainViewModel : ViewModelBase
            {
                private readonly IDataModel theModel;
        
                private ObservableCollection<DataItem> _DataItems;
        
                public ObservableCollection<DataItem> DataItems
                {
                    get
                    {
                        return _DataItems;
                    }
        
                    set
                    {
                        if (_DataItems == value)
                        {
                            return;
                        }
        
                        var oldValue = _DataItems;
                        _DataItems = value;
                        RaisePropertyChanged(() => DataItems, oldValue, value, true);
                    }
                }
        
        
                private string _ButtonText = "First";
                public string ButtonText
                {
                    get
                    {
                        return this._ButtonText;
                    }
        
                    set
                    {
                        if (this._ButtonText == value)
                        {
                            return;
                        }
        
                        var oldValue = this._ButtonText;
                        this._ButtonText = value;
                        RaisePropertyChanged(() => ButtonText, oldValue, value, true);
                    }
                }
        
        
                private string _UCTitle = string.Empty;
                public string UCTitle
                {
                    get
                    {
                        return this._UCTitle;
                    }
        
                    set
                    {
                        if (this._UCTitle == value)
                        {
                            return;
                        }
        
                        var oldValue = this._UCTitle;
                        this._UCTitle = value;
                        RaisePropertyChanged(() => UCTitle, oldValue, value, true);
                    }
                }
        
                private ICommand _ButtonCommand;
                public ICommand ButtonCommand
                {
                    get
                    {
                        return this._ButtonCommand;
                    }
        
                    set
                    {
                        if (this._ButtonCommand == value)
                        {
                            return;
                        }
        
                        var oldValue = this._ButtonCommand;
                        this._ButtonCommand = value;
                        RaisePropertyChanged(() => ButtonCommand, oldValue, value, true);
                    }
                }
        
                public MainViewModel(IDataModel model)
                {
                    this.theModel = model;
                    this._UCTitle = "DataGrid in User Control Demo";
                    this._DataItems = new ObservableCollection<DataItem>(this.theModel.SomeData);
                    this._ButtonCommand = new RelayCommand(this.ButtonCmd, () => { return true; }) ;
                }
        
                private void ButtonCmd()
                {
                    if (this.ButtonText == "First")
                    {
                        this.ButtonText = "Second";
                    }
                    else
                    {
                        this.ButtonText = "First";
                    }
                }
            }
        }
