        using System;
        using System.ComponentModel;
        using System.IO;
        using System.Windows;
        using System.Windows.Input;
        using System.Collections.ObjectModel;
        namespace StackOverflow_PopulateListView
        {
            /// <summary>
            /// Interaction logic for MainWindow.xaml
            /// </summary>
            public partial class MainWindow : Window
            {
                public MainWindow()
                {
                    InitializeComponent();
                    DataContext = new OpenFileDialogVM();
                }
            }
            public class OpenFileDialogVM : ViewModelBase
            {
                public static RelayCommand OpenCommand { get; set; }
                private string _selectedPath = "Enter a Path";
                public string SelectedPath
                {
                    get { return _selectedPath; }
                    set
                    {
                        _selectedPath = value;
                        OnPropertyChanged("SelectedPath");
                    }
                }
                private ObservableCollection<string> _files = new ObservableCollection<string>() { "Tits", "balls", "ass", "tits" };
                public ObservableCollection<string> Files
                {
                    get { return _files; }
                    set
                    {
                        _files = value;
                        OnPropertyChanged("Files");
                    }
                }
                private ICommand _selectFileCommand;
                public ICommand SelectFileCommand
                {
                    get
                    {
                        return _selectFileCommand ?? (_selectFileCommand = new RelayCommand(() => Call(SelectedPath)));
                    }
                    protected set
                    {
                        _selectFileCommand = value;
                    }
                }
                public void Call(string selectedpath)
                {
                    try
                    {
                        Files = new ObservableCollection<string>(Directory.GetFiles(selectedpath, "*", SearchOption.AllDirectories));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                        throw ex;
                    }
                }
            }
            public class RelayCommand : ICommand
            {
                public Action Act { get; set; }
                /// <summary> Occurs when the target of the Command should reevaluate whether or not the Command can be executed. </summary>
                public event EventHandler CanExecuteChanged;
                public RelayCommand(Action act)
                {
                    Act = act;
                }
                /// <summary> Returns a bool indicating if the Command can be exectued with the given parameter </summary>
                public bool CanExecute(object obj)
                {
                    return true;
                }
                /// <summary> Send a ICommand.CanExecuteChanged </summary>
                public void ChangeCanExecute()
                {
                    object sender = this;
                    EventArgs eventArgs = null;
                    CanExecuteChanged(sender, eventArgs);
                }
                /// <summary> Invokes the execute Action </summary>
                public void Execute(object obj)
                {
                    Act();
                }
            }
            /// <summary>
            /// Extremely generic ViewModelBase; for copy-pasting into almost any MVVM project
            /// </summary>
            public class ViewModelBase : INotifyPropertyChanged
            {
                public event PropertyChangedEventHandler PropertyChanged;
                /// <summary>
                /// Fires PropertyChangedEventHandler, for bindables
                /// </summary>
                protected virtual void OnPropertyChanged(string name)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
                }
            }
        }
