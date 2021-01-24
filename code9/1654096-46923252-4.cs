    <ListView x:Name='lv' Height="150" HorizontalAlignment="Center" VerticalAlignment="Center" GridViewColumnHeader.Click="GridViewColumnHeaderClickedHandler">
        <ListView.Resources>
            <DataTemplate x:Key="YearTemplate">
                <TextBlock Text="{Binding Year}" TextAlignment="Center"  />
            </DataTemplate>
            <DataTemplate x:Key="MonthTemplate">
                <TextBlock Text="{Binding Month}" TextAlignment="Center"  />
            </DataTemplate>
            <DataTemplate x:Key="DayTemplate">
                <TextBlock Text="{Binding Day}" TextAlignment="Center"  />
            </DataTemplate>
        </ListView.Resources>
    
        <ListView.ItemsSource>
            <collections:ArrayList>
                <system:DateTime>1993/1/1 12:22:02</system:DateTime>
                <system:DateTime>1993/1/2 13:2:01</system:DateTime>
                <system:DateTime>1997/1/3 2:1:6</system:DateTime>
                <system:DateTime>1997/1/4 13:6:55</system:DateTime>
                <system:DateTime>1999/2/1 12:22:02</system:DateTime>
                <system:DateTime>1998/2/2 13:2:01</system:DateTime>
                <system:DateTime>2000/2/3 2:1:6</system:DateTime>
                <system:DateTime>2002/2/4 13:6:55</system:DateTime>
                <system:DateTime>2001/3/1 12:22:02</system:DateTime>
                <system:DateTime>2006/3/2 13:2:01</system:DateTime>
                <system:DateTime>2004/3/3 2:1:6</system:DateTime>
                <system:DateTime>2004/3/4 13:6:55</system:DateTime>
            </collections:ArrayList>
        </ListView.ItemsSource>
        
        <ListView.View>
            <GridView>
                <GridViewColumn CellTemplate="{StaticResource YearTemplate}" local:GridViewColumnAttachedProperties.SortPropertyName="Year" />
                <GridViewColumn CellTemplate="{StaticResource MonthTemplate}" local:GridViewColumnAttachedProperties.SortPropertyName="Month" />
                <GridViewColumn CellTemplate="{StaticResource DayTemplate}" local:GridViewColumnAttachedProperties.SortPropertyName="Day" />
            </GridView>
        </ListView.View>
    </ListView>
