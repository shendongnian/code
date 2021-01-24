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
        Make it use a Canvas to be the actual container for the items, so we can control 
        their position arbitrarily, instead of the default StackPanel that just stacks 
        them up vertically.
        -->
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Canvas />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <!--
        The ItemsControl will put the instantiated item templates in ContentPresenters 
        that it creates. The positioning attributes have to go on the ContentPresenters, 
        because those are the direct children of the Canvas. The ContentPresenters are 
        the "item containers". You can customize them via the ItemContainerStyle property 
        of the ItemsControl. 
        -->
        <ItemsControl.ItemContainerStyle>
            <Style TargetType="ContentPresenter">
                <!-- 
                The datacontext will be CardViewModel.
                
                Bind Canvas.Left and Canvas.Top to appropriate properties 
                of CardViewModel. I'll assume it's got Point Position { get; }
                A much better, more "pure MVVM" way to do this is for the items to 
                provide some kind of abstraction, maybe row/column or something else,  
                and either place them in a Grid or UniformGrid or some other kind of 
                dynamic layout control, or else convert that abstraction into Canvas
                coordinates with a value converter on the Binding. 
                Then you can display the same item objects in different ways at the same 
                time without locking them into one layout. 
                Don't drive yourself crazy striving for ideological purity at the expense 
                of getting code out the door, but do consider redesigning that part. 
                -->
                <Setter Property="Canvas.Left" Value="{Binding Position.X}" />
                <Setter Property="Canvas.Top" Value="{Binding Position.Y}" />
            </Style>
        </ItemsControl.ItemContainerStyle>
