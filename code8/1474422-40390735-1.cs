    using System;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    namespace Karaoke
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                ViewModel.TextFont = 25;
                ViewModel.ChordFont = 20;
                SongData();
            }
    
            private void SongData()
            {
                ObservableCollection<ItemViewModel> Song = new ObservableCollection<ItemViewModel>();
    
                Song.Add(new ItemViewModel("The dog and the cat",
                         new List<ChordData>() { new ChordData("D", 0) }));
                Song.Add(new ItemViewModel("They take up the middle",
                         new List<ChordData>()));
                Song.Add(new ItemViewModel("Where the honey bee hums",
                         new List<ChordData>() { new ChordData("A", 8) }));
                Song.Add(new ItemViewModel("And Coyote howls",
                         new List<ChordData>() { new ChordData("A", 2), new ChordData("D", 9) }));
                ViewModel.Song = Song;
            }
    
            // C#6.O
            // public MainViewModel ViewModel => (MainViewModel)DataContext;
            public MainViewModel ViewModel
            {
                get { return (MainViewModel)DataContext; }
            }
        }
    }
