        <CheckBox Grid.Row="0" Grid.Column="1" Margin="0,20" 
                  IsChecked="{Binding Path = TimeIsEnabled, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged }"
                  DataContext="{Binding ElementName = MainWindowViewModel}">
            TestIsEnabled
        </CheckBox>
    
