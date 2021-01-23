    //ProcessShortcut.cs
    public class ProcessShortcut
    {
        public string DisplayName {get; set;}
        public string ProcessName {get; set;}
    }
    
    //MyViewModel.cs, include the previous code
    
    //INotifyPropertyChanged left out for brevity
    public IEnumerable<ProcessShortcut> Shortcuts {get; set;} 
    
    public MyViewModel()
    {
        Shortcuts = new List<ProcessShortcut>()
        {
            new ProcessShortcut(){DisplayName = "IE", ProcessName="IExplorer.exe"},
            new ProcessShortcut(){DisplayName = "Notepad", ProcessName="notepad.exe"},
            new ProcessShortcut(){DisplayName = "Chrome", ProcessName="chrome.exe"},
        };
    }
    
    //MyView.xaml
    <Window x:Name="Root">
    ...
       <ItemsControl ItemsSource="{Binding Shortcuts}">
          <ItemsControl.ItemTemplate>
              <DataTemplate>
                  <Button Content="{Binding DisplayName, StringFormat='{}Start {0}'}" 
                          Command="{Binding ElementName=Root, Path=LaunchAppCommand}" 
                          CommandParameter="{Binding ProcessName}"/>
              </DataTemplate>
          </ItemsControl.ItemTemplate>
       </ItemsControl>
    ...
    </Window>
