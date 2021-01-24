    <ListView  x:Name="ListView" Grid.Row="1" Grid.ColumnSpan="2" ItemsSource="{Binding ProjectsPMod}" Margin="110,0,110,131" HorizontalContentAlignment="Stretch" BorderThickness="0" Height="111" VerticalAlignment="Bottom">
        <interactivity:Interaction.Triggers>
            <interactivity:EventTrigger EventName="SelectionChanged">
                <cal:ActionMessage MethodName="OpenProjectShell">
                    <cal:Parameter Value="{Binding ElementName=ListView, Path=SelectedItem}" />
                </cal:ActionMessage>
            </interactivity:EventTrigger>
        </interactivity:Interaction.Triggers>
        <ListView.ItemTemplate>
            <DataTemplate>
                <StackPanel>
                    <StackPanel Orientation="Horizontal">
                        <ContentControl  Content="{StaticResource  Appbar_Suitcase}" />
                        <Label Content="{Binding Name}"/>
                    </StackPanel>
                    <Separator HorizontalAlignment="Stretch" Margin="0, 10, 0, 0"/>
                    <Button Margin="0 10 0 0" Content="Link" Cursor="Hand" Command="{Binding YourCommand}">
                        <Button.Template>
                            <ControlTemplate TargetType="Button">
                                <TextBlock TextDecorations="Underline">
                                    <ContentPresenter />
                                </TextBlock>
                            </ControlTemplate>
                        </Button.Template>
                        <Button.Style>
                            <Style TargetType="Button">
                                <Setter Property="Foreground" Value="Blue" />
                                <Style.Triggers>
                                    <Trigger Property="IsMouseOver" Value="True">
                                        <Setter Property="Foreground" Value="Red" />
                                    </Trigger>
                                </Style.Triggers>
                            </Style>
                        </Button.Style>
                    </Button>
                </StackPanel>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
