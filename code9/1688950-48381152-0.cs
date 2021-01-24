    <StackPanel Grid.Column="1">
            <StackPanel.Resources>
                <DataTemplate x:Key="DefaultTemplate" DataType="{x:Type sys:String}">
                    <StackPanel>
                        <TextBlock Text="{Binding .}"/>
                        <ListView>
                            <ListView.ItemsSource>
                                <CompositeCollection>
                                    <sys:String>Sub Item</sys:String>
                                </CompositeCollection>
                            </ListView.ItemsSource>
                            <ListView.ItemTemplate>
                                <DataTemplate>
                                    <TextBlock Text="{Binding}">
                                        <TextBlock.InputBindings>
                                            <MouseBinding Gesture="LeftDoubleClick" Command="{Binding DataContext.RenameCommand, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type local:MainWindow}}, PresentationTraceSources.TraceLevel=High}" CommandParameter="{Binding SelectedItem, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ListView}}}"/>
                                        </TextBlock.InputBindings>
                                    </TextBlock>
                                </DataTemplate>
                            </ListView.ItemTemplate>
                        </ListView>
                    </StackPanel>
                </DataTemplate>
            </StackPanel.Resources>
            
            <ListView ItemTemplate="{StaticResource DefaultTemplate}">
                <ListView.ItemsSource>
                    <CompositeCollection>
                        <sys:String> First Item</sys:String>
                    </CompositeCollection>
                </ListView.ItemsSource>
            </ListView>
        </StackPanel>  
