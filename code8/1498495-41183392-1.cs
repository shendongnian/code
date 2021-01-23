    public MainWindow()
    {
     InitializeComponent();
     IEnumerable<Image> images = GetChildren(Grid).OfType<Image>();
     if (images != null)
     {
        BitmapImage bi = new BitmapImage(new Uri("pic.png", UriKind.Relative));
        foreach (Image image in images)
        {
            image.Source = bi;
        }
      }
    }
    public static IEnumerable<Visual> GetChildren(Visual parent, bool recurse = true)
    {
      if (parent != null)
      {
          int count = VisualTreeHelper.GetChildrenCount(parent);
          for (int i = 0; i < count; i++)
          {
             // Retrieve child visual at specified index value.
            var child = VisualTreeHelper.GetChild(parent, i) as Visual;
            if (child != null)
            {
                yield return child;
                if (recurse)
                {
                    foreach (var grandChild in GetChildren(child, true))
                    {
                        yield return grandChild;
                    }
                }
              }
           }
        }
      }
----------
      <Window x:Class="WpfApplication1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApplication1"
        mc:Ignorable="d"
        Title="MainWindow" Height="300" Width="300">
    <Grid x:Name="Grid">
     <Image ... />
    ....
