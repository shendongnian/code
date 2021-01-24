    <Style TargetType="{x:Type avalonDockControls:LayoutDocumentTabItem}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type avalonDockControls:LayoutDocumentTabItem}">
                    <avalonDockControls:DropDownControlArea 
                            DropDownContextMenu="{Binding Root.Manager.DocumentContextMenu}"
                            DropDownContextMenuDataContext="{Binding LayoutItem, RelativeSource={RelativeSource TemplatedParent}}" >
                        <Border Background="{TemplateBinding Background}"
                            BorderBrush="{TemplateBinding BorderBrush}"
                            BorderThickness="{TemplateBinding BorderThickness}">
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="*"/>
                                    <ColumnDefinition Width="Auto"/>
                                </Grid.ColumnDefinitions>
                                <Border Grid.ColumnSpan="2" Background="Transparent"/>
                                <ContentPresenter Content="{Binding Model, RelativeSource={RelativeSource TemplatedParent}}" 
                                              ContentTemplate="{Binding DocumentHeaderTemplate, Mode=OneWay, RelativeSource={RelativeSource AncestorType={x:Type avalonDock:DockingManager}, Mode=FindAncestor}}"
                                              ContentTemplateSelector="{Binding DocumentHeaderTemplateSelector, Mode=OneWay, RelativeSource={RelativeSource AncestorType={x:Type avalonDock:DockingManager}, Mode=FindAncestor}}"/>
                                <!-- Close button should be moved out to the container style -->
                                <Button x:Name="DocumentCloseButton" Style="{StaticResource {x:Static ToolBar.ButtonStyleKey}}" Grid.Column="1" Margin="5,0,0,0" Visibility="Hidden" 
                                        Command="{Binding Path=LayoutItem.CloseCommand, RelativeSource={RelativeSource TemplatedParent}}"
                                        ToolTip="{x:Static avalonDockProperties:Resources.Document_Close}">
                                    <Image Source="/Xceed.Wpf.AvalonDock;component/Themes/Generic/Images/PinClose.png"/>
                                </Button>
                            </Grid>
                        </Border>
                    </avalonDockControls:DropDownControlArea>
                    <ControlTemplate.Triggers>
                        <DataTrigger Binding="{Binding Path=IsSelected}" Value="true">
                            <Setter Property="Visibility" Value="Visible" TargetName="DocumentCloseButton"  />
                        </DataTrigger>
                        <!-- here is your trigger -->
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="Visibility" Value="Visible" TargetName="DocumentCloseButton"  />
                        </Trigger>
                        <DataTrigger Binding="{Binding Path=CanClose}" Value="false">
                            <Setter Property="Visibility" Value="Collapsed" TargetName="DocumentCloseButton"  />
                        </DataTrigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
