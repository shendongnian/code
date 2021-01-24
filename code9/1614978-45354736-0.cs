    <ListView.ItemTemplate>
        <DataTemplate>
            <Grid>
                <TextBlock 
                 FontFamily="Assets/Fonts/Baskerville.ttf#Baskerville" 
                 Foreground="White">
                    <Run Text="{Binding Path=groupedProduct.Name}"/>
                    <Run Text="{Binding PriceSum,
                                Converter={StaticResource PriceConverter}, 
                                Mode=TwoWay,
                                UpdateSourceTrigger=PropertyChanged}"/>
                    <LineBreak/>
                    <Run Text="{Binding Path=Count,
                                Converter={StaticResource StringFormatter},
                                ConverterParameter='Anzahl: {0}',
                                Mode=TwoWay,
                                UpdateSourceTrigger=PropertyChanged}"/>
            </Grid>
        </DataTemplate>
    </ListView.ItemTemplate>
