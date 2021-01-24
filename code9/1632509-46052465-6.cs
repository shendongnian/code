    <TreeView ItemsSource="{Binding ComponentsToDraw}">
        <TreeView.Resources>
            <HierarchicalDataTemplate DataType="{x:Type local:Component}" ItemsSource="{Binding ComponentsToDraw}">
                <Grid Canvas.Left="{Binding X}" Canvas.Top="{Binding Y}" Width="{Binding Width}" Height="{Binding Height}" Background="{Binding Color}">
                    <TextBlock Margin="8,5,0,0" FontWeight="Bold" Text="{Binding Name}" />
                </Grid>
            </HierarchicalDataTemplate>
            <Style TargetType="{x:Type TreeViewItem}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type TreeViewItem}">
                            <Canvas>
                                <ContentPresenter x:Name="PART_Header" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" ContentSource="Header">
                                        <ContentPresenter.Style>
                                            <Style TargetType="ContentPresenter">
                                                <Setter Property="Canvas.Left" Value="{Binding Path=X}" />
                                                <Setter Property="Canvas.Top" Value="{Binding Path=Y}" />
                                            </Style>
                                        </ContentPresenter.Style>
                                    </ContentPresenter>      
                                <ItemsPresenter/>
                            </Canvas>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </TreeView.Resources>           
    </TreeView>
