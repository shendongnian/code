    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    
    namespace WpfApp13
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                ((MainWindowViewModel)DataContext).PlayToggle(4); // I'm too lazy to use an ICommand...
            }
        }
    
        public class MainWindowViewModel : DependencyObject
        {
            public ObservableCollection<FileInformation> FilesCollection
            {
                get { return (ObservableCollection<FileInformation>)GetValue(FilesCollectionProperty); }
                set { SetValue(FilesCollectionProperty, value); }
            }
            public static readonly DependencyProperty FilesCollectionProperty = DependencyProperty.Register("FilesCollection", typeof(ObservableCollection<FileInformation>), typeof(MainWindowViewModel), new PropertyMetadata(null));
    
            public MainWindowViewModel()
            {
                FilesCollection = new ObservableCollection<FileInformation>() {
                    new FileInformation() { Title = "File 1", IsPlaying = false, Time = new TimeSpan(0, 5, 1) },
                    new FileInformation() { Title = "File 2", IsPlaying = false, Time = new TimeSpan(0, 5, 2) },
                    new FileInformation() { Title = "File 3", IsPlaying = false, Time = new TimeSpan(0, 5, 3) },
                    new FileInformation() { Title = "File 4", IsPlaying = false, Time = new TimeSpan(0, 5, 4) },
                    new FileInformation() { Title = "File 5", IsPlaying = false, Time = new TimeSpan(0, 5, 5) },
                    new FileInformation() { Title = "File 6", IsPlaying = false, Time = new TimeSpan(0, 5, 6) },
                    new FileInformation() { Title = "File 7", IsPlaying = false, Time = new TimeSpan(0, 5, 7) },
                    new FileInformation() { Title = "File 8", IsPlaying = false, Time = new TimeSpan(0, 5, 8) },
                    new FileInformation() { Title = "File 9", IsPlaying = false, Time = new TimeSpan(0, 5, 9) },
                };
            }
    
            public void PlayToggle(int idx)
            {
                FilesCollection[idx].IsPlaying = !FilesCollection[idx].IsPlaying;
            }
        }
    
        public class FileInformation : DependencyObject
        {
            public static readonly DependencyProperty IsPlayingProperty = DependencyProperty.Register(nameof(IsPlaying), typeof(bool), typeof(FileInformation), new PropertyMetadata(null));
            //private bool _isPlaying = false;
            public bool IsPlaying
            {
                get => (bool)GetValue(IsPlayingProperty);
                set
                {
                    SetValue(IsPlayingProperty, value);
                    OnPropertyChanged();
                }
            }
    
            public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(FileInformation), new PropertyMetadata(null));
            public string Title
            {
                get => (string)GetValue(TitleProperty);
                set
                {
                    SetValue(TitleProperty, value);
                    OnPropertyChanged();
                }
            }
    
            public TimeSpan Time
            {
                get { return (TimeSpan)GetValue(TimeProperty); }
                set { SetValue(TimeProperty, value); }
            }
            public static readonly DependencyProperty TimeProperty = DependencyProperty.Register("Time", typeof(TimeSpan), typeof(FileInformation), new PropertyMetadata(null));
    
    
            public event PropertyChangedEventHandler PropertyChanged;
            //[NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }
    
        public class TestConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                // value = IsPlaying
                if (value is bool b)
                {
                    return b;
                }
                return null;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return value; // Needed because IsPlaying is twoway bound to IsSelected.
            }
        }
    
        public class TimeSpanFormatConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                // value = Time
                if (value is TimeSpan ts)
                {
                    return $"{ts.Minutes} minutes {ts.Seconds} seconds";
                }
                return null;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
