    <Window.Resources>
        <local:ListViewEvenColumnWidthConverter x:Key="EvenColumnWidthConverter" ColumnCount="4" />
    </Window.Resources>
    ...
     <ListView x:Name="listView" ScrollViewer.HorizontalScrollBarVisibility="Disabled">
         <ListView.View>
             <GridView>
                 <GridViewColumn Header="Date" Width="{Binding ElementName=listView, Path=ActualWidth, Converter={StaticResource EvenColumnWidthConverter}}" />
                 <GridViewColumn Header="Supplier" Width="{Binding ElementName=listView, Path=ActualWidth, Converter={StaticResource EvenColumnWidthConverter}}" />
                 <GridViewColumn Header="Product" Width="{Binding ElementName=listView, Path=ActualWidth, Converter={StaticResource EvenColumnWidthConverter}}" />
                 <GridViewColumn Header="Quantity Sold" Width="{Binding ElementName=listView, Path=ActualWidth, Converter={StaticResource EvenColumnWidthConverter}}" />
                 ...
            </GridView>
        </ListView.View>
            Test Text
    </ListView>
