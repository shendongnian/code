    using System;
    using System.Windows;
    
    namespace WpfApp2
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var level0 = new Directory("level 0");
                var level1 = level0.Add(new Directory("level 1"));
                var level2 = level1.Add(new Directory("level 2"));
                var file1 = level2.Add(new File("file 1"));
                var file2 = level2.Add(new File("file 2"));
                DataContext = new[] {level0}; // to show root in tree
            }
    
            private Random Random { get; } = new Random();
    
            private Directory SelectedDirectory { get; set; }
    
            private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
            {
                SelectedDirectory = e.NewValue as Directory;
                Button.IsEnabled = SelectedDirectory != null;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                var next = Random.Next(2);
    
                switch (next)
                {
                    case 0:
                        SelectedDirectory.Add(new Directory("New directory"));
                        break;
                    case 1:
                        SelectedDirectory.Add(new File("New file"));
                        break;
                }
            }
        }
    }
