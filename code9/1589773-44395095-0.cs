    <UserControl x:Class="WpfDemos.FolderPicker"
                 x:Name="folderPicker"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
                 xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
                 mc:Ignorable="d" 
                 d:DesignHeight="75" d:DesignWidth="300">
        <StackPanel>
            <Label Content="{Binding Path=Title, ElementName=folderPicker}"/>
            <TextBox x:Name="SelectedFolderTextBox" 
                     Text="{Binding Path=FullPath, ElementName=folderPicker,
                                    UpdateSourceTrigger=PropertyChanged}"/>
            <Button Content="..." Click="PickClick"/>
        </StackPanel>
    </UserControl>
<!---->
    public partial class FolderPicker : UserControl
    {
        public FolderPicker()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title", typeof (string), typeof (FolderPicker), new PropertyMetadata("Folder"));
        public string Title
        {
            get { return (string) GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty FullPathProperty = DependencyProperty.Register(
            "FullPath", typeof (string), typeof (FolderPicker), new FrameworkPropertyMetadata(@"C:\", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string FullPath
        {
            get { return (string) GetValue(FullPathProperty); }
            set { SetValue(FullPathProperty, value); }
        }
        private void PickClick(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    FullPath = dialog.SelectedPath;
            }
        }
    }
