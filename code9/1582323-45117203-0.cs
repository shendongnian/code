    <ScrollViewer>
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="Auto"></ColumnDefinition>
                <ColumnDefinition></ColumnDefinition>
            </Grid.ColumnDefinitions>
    
            <ListView Grid.Column="0" Name="LineNumbers" ScrollViewer.VerticalScrollMode="Disabled" ScrollViewer.VerticalScrollBarVisibility="Disabled"></ListView>
            <RichEditBox Grid.Column="1" x:Name="RebText" TextChanged="RebText_TextChanged" ScrollViewer.VerticalScrollMode="Disabled" ScrollViewer.VerticalScrollBarVisibility="Disabled"></RichEditBox>
        </Grid>
    </ScrollViewer>
