    <ContentView Grid.Row="0"
                       Grid.Column="1"
                       IsVisible="{Binding EntryEnabled}">
            <Entry IsEnabled="True"
                   Text="{Binding PropertyValue, Mode=TwoWay}"/>
    </ContentView>
    
    <ContentView Grid.Row="0"
                 Grid.Column="1"
                  IsVisible="{Binding EntryEnabled, Converter={StaticResource InverseConverter}}">
            <Entry IsEnabled="False"
                   Text="{Binding PropertyValue, Mode=TwoWay}"/>
    </ContentView>
