    using System.Collections.ObjectModel;
    using System.Windows;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.CommandWpf;
    
    namespace WpfApp1
    {
        public class Model : ViewModelBase
        {
            public Model()
            {
                Files = new ObservableCollection<string>();
    
                Load = new RelayCommand<DragEventArgs>(e =>
                {
                    var files = e.Data.GetData(DataFormats.FileDrop) as string[];
                    if (files == null)
                        return;
    
                    foreach (var file in files)
                    {
                        Files.Add(file);
                    }
                });
            }
    
            public RelayCommand<DragEventArgs> Load { get; }
    
            public ObservableCollection<string> Files { get; }
        }
    }
