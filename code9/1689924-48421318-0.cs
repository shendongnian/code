    <TreeView>
        <FrameworkElement.Resources>
            <CollectionViewSource x:Key="Items"
                                  Source="{Binding Items}"
                                  Filter="Items_Filter"
                                  IsLiveFilteringRequested="True"
                                  xmlns:sys="clr-namespace:System;assembly=mscorlib">
                <CollectionViewSource.LiveFilteringProperties>
                    <sys:String>IsVisible</sys:String>
                </CollectionViewSource.LiveFilteringProperties>
            </CollectionViewSource>
        </FrameworkElement.Resources>
        <ItemsControl.ItemsSource>
            <Binding Source="{StaticResource Items}" />
        </ItemsControl.ItemsSource>
    </TreeView>
