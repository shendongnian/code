    <Window x:Class="ReadImageSourceWpf.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:ReadImageSoureWpf"
            mc:Ignorable="d"
            Title="MainWindow" Height="612" Width="512">
        <StackPanel Orientation="Vertical">
            <Image Name="img" Stretch="Fill" Loaded="img_Loaded"/>
            <Button Name="btnConvert" Content="Convert..." Background="Firebrick" BorderBrush="White" Click="btnConvert_Click" HorizontalAlignment="Center" VerticalAlignment="Center" Width="75" Height="40"/>
        </StackPanel>
    </Window>
    using Emgu.CV;
    using Emgu.CV.Structure;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    namespace ReadImageSourceWpf
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            #region Public Constructors
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            #endregion Public Constructors
    
            #region Private Methods
    
            private void btnConvert_Click(object sender, RoutedEventArgs e)
            {
                Mat readImage = new Mat();
    
                readImage = BitmapSourceConvert.ToMat((BitmapSource)img.Source);
    
                Image<Bgra, Byte> newImg = new Image<Bgra, byte>(readImage.Bitmap);
    
                BitmapSource bs = BitmapSourceConvert.ToBitmapSource(newImg);
    
                Window convImageWin = new ConvertedImageWindow((ImageSource)bs);
    
                convImageWin.Show();
            }
    
            private void img_Loaded(object sender, RoutedEventArgs e)
            {
                BitmapImage b = new BitmapImage();
                b.BeginInit();
                b.UriSource = new Uri(@"D:\OpenCV\opencv-3.2.0\samples\data\Lena.jpg");
                b.EndInit();
                var image = sender as Image;
                image.Source = b;
            }
    
            #endregion Private Methods
        }
    }
