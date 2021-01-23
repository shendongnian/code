    <ContentControl>
        <ContentControl.Resources>
            <BoolConverter x:Key="BoolToLayoutConverter" TrueValue="templateHorizontal" FalseValue="templateVertical"/>
            <BoolConverter x:Key="BoolToLayoutCharacterConverter" TrueValue="—" FalseValue="|"/>
            <DataTemplate x:Key="mainTable">
                <StackPanel>
                    <Label Content="MainTable goes here"/>
                    <ToggleButton Content="{Binding LayoutHorizontal, Converter={StaticResource BoolToLayoutCharacterConverter}}" 
                            IsChecked="{Binding LayoutHorizontal}"/>
                </StackPanel>
            </DataTemplate>
            <DataTemplate x:Key="childTables">
                <Label Content="ChildTables go here"/>
            </DataTemplate>
        </ContentControl.Resources>
        <ContentControl.Style>
           <Style TargetType="ContentControl">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding LayoutHorizontal}" Value="False">
                        <Setter Property="ContentTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                    <Grid>
                                       <Grid.ColumnDefinitions>
                                            <ColumnDefinition/>
                                            <ColumnDefinition Width="10"/>
                                            <ColumnDefinition/>
                                        </Grid.ColumnDefinitions>
                                        <ContentPresenter Grid.Column="0" ContentTemplate="{StaticResource mainTable}"/>
                                        <GridSplitter Grid.Column="1" HorizontalAlignment="Stretch" VerticalAlignment="Stretch"/>
                                        <ContentPresenter Grid.Column="2" ContentTemplate="{StaticResource childTables}"/>
                                    </Grid>
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding LayoutHorizontal}" Value="True">
                        <Setter Property="ContentTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                    <Grid>
                                        <Grid.RowDefinitions>
                                            <RowDefinition/>
                                            <RowDefinition Height="5"/>
                                            <RowDefinition/>
                                        </Grid.RowDefinitions>
                                        <ContentPresenter Grid.Row="0" ContentTemplate="{StaticResource mainTable}"/>
                                        <GridSplitter Grid.Row="1" Height="10" VerticalAlignment="Stretch" HorizontalAlignment="Stretch"/>
                                        <ContentPresenter Grid.Row="2" ContentTemplate="{StaticResource childTables}"/>
                                    </Grid>
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ContentControl.Style>
    </ContentControl>
