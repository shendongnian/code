    <ComboBox Name="cb_farbe" Text="farbe" HorizontalContentAlignment="Center" IsEditable="True" Grid.Row="7" 
                      Grid.Column="1" VerticalAlignment="Center" Grid.ColumnSpan="2" Loaded="CbFarbe">
        <ComboBox.ItemContainerStyle>
            <Style TargetType="ComboBoxItem">
                <Setter Property="HorizontalContentAlignment" Value="Stretch" />
                <Setter Property="VerticalContentAlignment" Value="Stretch" />
                <Setter Property="Background">
                    <Setter.Value>
                        <SolidColorBrush Color="{Binding}" />
                    </Setter.Value>
                </Setter>
            </Style>
        </ComboBox.ItemContainerStyle>
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding}" />
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
----------
    private void CbFarbe(object sender, RoutedEventArgs e)
    {
        List<System.Windows.Media.Color> colors = new List<System.Windows.Media.Color>
                {
                   System.Windows.Media.Colors.Blue,
                   System.Windows.Media.Colors.Green,
                   System.Windows.Media.Colors.LightBlue,
                   System.Windows.Media.Colors.Black,
                   System.Windows.Media.Colors.White,
                   System.Windows.Media.Colors.Gray
                };
        var comboBox = sender as ComboBox;
        comboBox.ItemsSource = colors;
        comboBox.SelectedIndex = 1;
    }
