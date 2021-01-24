      using System.Collections.Generic;
        using System.ComponentModel;
        using System.Runtime.CompilerServices;
        using TestWpfApplication.Properties;
        
        namespace TestWpfApplication
        {
            public class MainWindowViewModel : INotifyPropertyChanged
            {
                private bool _isItemEnabled;
                private IList<OptType> _optimizationTypes;
                private OptimizeTypes _selectedIndex;
                public event PropertyChangedEventHandler PropertyChanged;
        
                public OptimizeTypes SelectedIndex
                {
                    get { return _selectedIndex;}
                    set
                    {
                        _selectedIndex = value;
                        OnPropertyChanged(nameof(SelectedIndex));
                    }
                }
                
                
                public IList<OptType> OptimizationTypes
                {
                    get { return _optimizationTypes; }
                    set
                    {
                        _optimizationTypes = value;
                        OnPropertyChanged(nameof(OptimizationTypes));
                    }
                }
        
                public bool IsItemEnabled
                {
                    get { return _isItemEnabled; }
                    set
                    {
                        _isItemEnabled = value;
                        InitOptimizationTypes(value);
                        OnPropertyChanged(nameof(IsItemEnabled));
                    }
                }
        
        
                public MainWindowViewModel()
                {                        
                    InitOptimizationTypes(false);
                }
        
                private  void InitOptimizationTypes(bool isEnabled)
                {
                    OptimizationTypes = new List<OptType>
                    {
                        new OptType
                        {
                            TypeName = "Time",
                            IsItemEnabled = isEnabled,
                        },
                        new OptType
                        {
                            TypeName = "Cost",
                            IsItemEnabled = true,
                        },
                        new OptType
                        {
                            TypeName = "Fuel",
                            IsItemEnabled = true,
                        }
                    };
                }
        
                [NotifyPropertyChangedInvocator]
                protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
    using System.Collections;
    
    namespace TestWpfApplication
    {
        public class OptType
        {
            public string TypeName { get;  set; }
            public bool IsItemEnabled { get;  set; }
        }
    }
    
              <Window x:Class="TestWpfApplication.MainWindow"
                xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
                xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                xmlns:local="clr-namespace:TestWpfApplication"
                mc:Ignorable="d"
                Title="MainWindow" Height="350" Width="525">
        
            <Window.DataContext>
                <local:MainWindowViewModel />
            </Window.DataContext>
        
            <Grid>
                <CheckBox Grid.Row="0" IsChecked="{Binding IsItemEnabled}" Margin="11,30,15,129">IsItemEnabled</CheckBox>
                <ComboBox Grid.Row="0" Margin="15,54,352,231" IsSynchronizedWithCurrentItem="True"
                          ItemsSource="{Binding OptimizationTypes}" DisplayMemberPath="TypeName"  
                          SelectedIndex="{Binding SelectedIndex,  Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                          >
                    <ComboBox.ItemContainerStyle>
                        <Style TargetType="{x:Type ComboBoxItem}">
                            <Setter Property="IsEnabled" Value="{Binding IsItemEnabled}"/>
                        </Style>
                    </ComboBox.ItemContainerStyle>
                    </ComboBox>
            </Grid>
        </Window
    
    >
