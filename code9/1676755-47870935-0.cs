     <Grid>
    
            <HeaderedItemsControl>
                <HeaderedItemsControl.Template>
                    <ControlTemplate TargetType="{x:Type HeaderedItemsControl}">
                        <Border>
                            <Grid>
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="Auto" />
                                    <RowDefinition Height="Auto" />
                                    <RowDefinition />
                                </Grid.RowDefinitions>
                                <ContentPresenter ContentSource="Header" />
                                <!--<Separator Grid.Row="1" />-->
                                <ScrollViewer Grid.Row="2" VerticalScrollBarVisibility="Visible">
                                    <ItemsPresenter />
                                </ScrollViewer>
                            </Grid>
                        </Border>
                    </ControlTemplate>
                </HeaderedItemsControl.Template>
                <HeaderedItemsControl.Header>Mark</HeaderedItemsControl.Header>
                <HeaderedItemsControl.Items>
                    <system:String>Mark2</system:String>
                    <system:String>Mark3</system:String>
                    <system:String>Mark4</system:String>
                    <system:String>Mark5</system:String>
                    <system:String>Mark6</system:String>
                    <system:String>Mark7</system:String>
                    <system:String>Mark7</system:String>
                </HeaderedItemsControl.Items>
            </HeaderedItemsControl>
        </Grid>
