    <ItemsControl
        ItemsSource="{Binding Cards}"
        >
        <!-- 
        This creates UI for each item. There are other ways, if you've got a collection 
        of heterogeneous item types.
        -->  
        <ItemsControl.ItemTemplate>
            <DataTemplate DataType="local:CardViewModel">
                <views:CardView />
            </DataTemplate>
        </ItemsControl.ItemTemplate>
        <!-- 
        Make it use a Canvas to as a parent for the items, so we can control their 
        position, instead of the default StackPanel that just lines them up.
        -->
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Canvas />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <!--
        The instantiated item templates go in a bunch of ContentPresenters. That's where 
        the positioning attributes have to go, because those are the direct children
        of the Canvas. 
        -->
        <ItemsControl.ItemContainerStyle>
            <Style TargetType="ContentPresenter">
                <!-- 
                The datacontext will be CardViewModel.
                
                Bind Canvas.Left and Canvas.Top to appropriate properties 
                of CardViewModel. I'll assume it's got Point Position { get; }
                -->
                <Setter Property="Canvas.Left" Value="{Binding Position.X}" />
                <Setter Property="Canvas.Top" Value="{Binding Position.Y}" />
            </Style>
        </ItemsControl.ItemContainerStyle>
