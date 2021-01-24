    <Window x:Class="WpfApp1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:WpfApp1"
            mc:Ignorable="d"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <TabControl x:Name="tabControl">
               
                <TabItem Header="Tab2">
                    <Grid x:Name="tab2">
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto"/>
                            <RowDefinition />
                        </Grid.RowDefinitions>
                        <ComboBox 
                            x:Name="comboBox" 
                            Height="32" 
                            VerticalAlignment="Top" 
                            Width="150" 
                            HorizontalAlignment="Left" 
                            UseLayoutRounding="True" 
                            SelectedIndex="-1" 
                            Text="Add New Column" 
                            IsEditable="True" 
                            IsReadOnly="True" 
                            Margin="50,0,0,0"
                            SelectionChanged="cob_Add_SelectionChanged"
                            ItemsSource="{Binding ComboBoxItems}"
                            />
    
                        <ListBox Width="400"  ItemsSource="{Binding MyList}" Grid.Row="1" x:Name="Test">
                            <ListBox.ItemTemplate>
                                <DataTemplate>
                                    <StackPanel>
                                        <Label Content="{Binding Label1}" />
                                            <TextBox Text="{Binding Text1}" />
                                            <Button Content="{Binding ButtonName}" Click="Button_Click"/>
                                            <CheckBox IsChecked="{Binding IsChecked}" />
                                        </StackPanel>
                                </DataTemplate>
                            </ListBox.ItemTemplate>
                        </ListBox>
    
                    </Grid>
                </TabItem>
            </TabControl>
        </Grid>
    </Window>
    
    
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Markup;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Xml;
    
    namespace WpfApp1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public ObservableCollection<DataElement> MyList { get; set; }
            public ObservableCollection<int> ComboBoxItems { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
                this.ComboBoxItems = new ObservableCollection<int>() { 1, 2, 3 };
                this.MyList = new ObservableCollection<DataElement>();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Button btn = sender as Button;
                DataElement dataContext = btn.DataContext as DataElement;
                // do something here <------
            }
    
            private void cob_Add_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                ComboBox cb = sender as ComboBox;
                int? comboBoxItemDataContext = cb.SelectedItem as int?;
    
                if (comboBoxItemDataContext == 1)
                {
                    this.MyList.Add(new DataElement() { Label1="1",  Text1 = "1", ButtonName = "1", IsChecked = true });
                }
                if (comboBoxItemDataContext == 2)
                {
                    this.MyList.Add(new DataElement() { Label1 = "2", Text1 = "2", ButtonName = "2", IsChecked = true });
                }
                if (comboBoxItemDataContext == 3)
                {
                    this.MyList.Add(new DataElement() { Label1 = "3", Text1 = "3", ButtonName = "3", IsChecked = true });
                }
            }
        }
    
        public class DataElement
        {
            public string Label1 { get; set; }
            public string Text1 { get; set; }
            public string ButtonName { get; set; }
            public bool IsChecked { get; set; }
        }
    
    }
