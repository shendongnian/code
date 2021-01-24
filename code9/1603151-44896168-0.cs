    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
    
    namespace ResourceTest
    {
        public partial class MainWindow 
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var dict = new ResourceDictionary();
    
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;
    
                foreach (var file in Directory.GetFiles("Images"))
                {
                    dict.Add(file, new BitmapImage(new Uri(Path.Combine(baseDir, file))));
                }
    
                Application.Current.Resources.MergedDictionaries.Add(dict);
    
                foreach (var file in Directory.GetFiles("Images"))
                {
                    var img = new Image();
                    img.Source = (BitmapImage) FindResource(file);
    
                    ListBox.Items.Add(img);
                }
            }
        }
    }
