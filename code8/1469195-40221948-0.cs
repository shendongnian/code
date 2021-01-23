    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    namespace WatchedFile.ViewModels
    {
        public class ViewModelBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public class WatchedFile : ViewModelBase
        {
            #region Name Property
            private String _name = default(String);
            public String Name
            {
                get { return _name; }
                set
                {
                    if (value != _name)
                    {
                        _name = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion Name Property
            #region Path Property
            private String _path = default(String);
            public String Path
            {
                get { return _path; }
                set
                {
                    if (value != _path)
                    {
                        _path = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion Path Property
            #region Tags Property
            private ObservableCollection<Tag> _tags = new ObservableCollection<Tag>();
            public ObservableCollection<Tag> Tags
            {
                get { return _tags; }
                protected set
                {
                    if (value != _tags)
                    {
                        _tags = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion Tags Property
        }
        public class Tag
        {
            public Tag(String value)
            {
                Value = value;
            }
            public String Value { get; private set; }
        }
        public class MainViewModel : ViewModelBase
        {
            public MainViewModel()
            {
                WatchedFiles = new ObservableCollection<WatchedFile>
                {
                    new WatchedFile() { Name = "foobar.txt", Path = "c:\\testfiles\\foobar.txt", Tags = { new Tag("Testfile"), new Tag("Text") } },
                    new WatchedFile() { Name = "bazfoo.txt", Path = "c:\\testfiles\\bazfoo.txt", Tags = { new Tag("Testfile"), new Tag("Text") } },
                    new WatchedFile() { Name = "whatever.xml", Path = "c:\\testfiles\\whatever.xml", Tags = { new Tag("Testfile"), new Tag("XML") } },
                };
            }
            #region WatchedFiles Property
            private ObservableCollection<WatchedFile> _watchedFiles = new ObservableCollection<WatchedFile>();
            public ObservableCollection<WatchedFile> WatchedFiles
            {
                get { return _watchedFiles; }
                protected set
                {
                    if (value != _watchedFiles)
                    {
                        _watchedFiles = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion WatchedFiles Property
        }
    }
