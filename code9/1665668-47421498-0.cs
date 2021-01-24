    <ListView ItemsSource="{Binding Items}">
        <ListView.Resources>
            <Style TargetType="ListViewItem">
                <Style.Triggers>
                    <MultiTrigger>
                        <MultiTrigger.Conditions>
                            <Condition Property="IsSelected" Value="True" />
                        </MultiTrigger.Conditions>
                        <MultiTrigger.Setters>
                            <Setter Property="Background" Value="Blue" />
                            <Setter Property="BorderBrush" Value="Blue" />
                            <Setter Property="Foreground" Value="White"/>
                        </MultiTrigger.Setters>
                    </MultiTrigger>
                </Style.Triggers>
            </Style>
        </ListView.Resources>
        <ListView.View>
            <GridView>
                <GridViewColumn>
                    <GridViewColumnHeader Content="Text"/>
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <Image Source="{Binding MyImage}" Width="20"/>
                                <Label Content="{Binding MyLabelText}" />
                            </StackPanel>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
            </GridView>
        </ListView.View>
    </ListView>
