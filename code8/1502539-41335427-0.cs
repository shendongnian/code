    <DataGrid x:Name="dgrid">
        <DataGrid.Resources>
            <Style TargetType="{x:Type DataGridRow}">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding}" Value="{x:Static CollectionView.NewItemPlaceholder}">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="{x:Type DataGridRow}">
                                    <Border x:Name="DGR_Border" BorderBrush="{TemplateBinding BorderBrush}"
                                                    BorderThickness="{TemplateBinding BorderThickness}" 
                                                    Background="{TemplateBinding Background}" SnapsToDevicePixels="True">
                                        <Grid>
                                            <SelectiveScrollingGrid>
                                                <SelectiveScrollingGrid.ColumnDefinitions>
                                                    <ColumnDefinition Width="Auto"/>
                                                    <ColumnDefinition Width="*"/>
                                                </SelectiveScrollingGrid.ColumnDefinitions>
                                                <SelectiveScrollingGrid.RowDefinitions>
                                                    <RowDefinition Height="*"/>
                                                    <RowDefinition Height="Auto"/>
                                                </SelectiveScrollingGrid.RowDefinitions>
                                                <DataGridCellsPresenter Grid.Column="1" ItemsPanel="{TemplateBinding ItemsPanel}" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
                                                <DataGridDetailsPresenter Grid.Column="1" Grid.Row="1" SelectiveScrollingGrid.SelectiveScrollingOrientation="{Binding AreRowDetailsFrozen, ConverterParameter={x:Static SelectiveScrollingOrientation.Vertical}, Converter={x:Static DataGrid.RowDetailsScrollingConverter}, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}" Visibility="{TemplateBinding DetailsVisibility}"/>
                                                <DataGridRowHeader Grid.RowSpan="2" SelectiveScrollingGrid.SelectiveScrollingOrientation="Vertical" Visibility="{Binding HeadersVisibility, ConverterParameter={x:Static DataGridHeadersVisibility.Row}, Converter={x:Static DataGrid.HeadersVisibilityConverter}, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}"/>
                                            </SelectiveScrollingGrid>
                                            <Button Content="Add New" />
                                        </Grid>
                                    </Border>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </DataGrid.Resources>
    </DataGrid>
