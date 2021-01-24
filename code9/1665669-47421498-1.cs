    <ListView ItemsSource="{Binding Items}">
        <ListView.Resources>
            <Style TargetType="ListViewItem">
                <Style.Triggers>
                    <Trigger Property="IsSelected" Value="True">
                        <Trigger.Setters>
                            <Setter Property="Background" Value="Blue" />
                            <Setter Property="BorderBrush" Value="Blue" />
                        </Trigger.Setters>
                    </Trigger>
                </Style.Triggers>
            </Style>
            <Style TargetType="Label">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding RelativeSource={RelativeSource AncestorType=ListViewItem}, Path=IsSelected}" Value="True">
                        <DataTrigger.Setters>
                            <Setter Property="Foreground" Value="White"></Setter>
                        </DataTrigger.Setters>
                    </DataTrigger>
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
