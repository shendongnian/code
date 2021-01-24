    <DataGrid Name="studentGrid" Grid.Row="3" Grid.ColumnSpan="2" AutoGenerateColumns="False"
                      ItemsSource="{Binding Students, Mode=TwoWay}" >
        <DataGrid.Resources>
            <Style x:Key="ReadOnlyStyle" TargetType="TextBox">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding StudentGrade, Converter={StaticResource converter}}" Value="True">
                        <Setter Property="BorderThickness" Value="0" />
                        <Setter Property="IsEnabled" Value="False" />
                        <Setter Property="Background" Value="Transparent" />
                        <Setter Property="TextWrapping" Value="Wrap" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTextColumn IsReadOnly="True" Header="Student's name" Binding="{Binding StudentName}" />
            <DataGridTextColumn IsReadOnly="True" Header="Student's username" Binding="{Binding StudentUserName}" />
            <DataGridTextColumn IsReadOnly="True" Header="Date of application" Binding="{Binding DateOfApplication}"  />
            <DataGridTextColumn Header="Student's grade" Binding="{Binding StudentGrade}" EditingElementStyle="{StaticResource ReadOnlyStyle}"/>
        </DataGrid.Columns>
    </DataGrid>
