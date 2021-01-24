    <Grid>
        <Grid.ColumnDefinitions>
            <!-- Made up width values -->
            <ColumnDefinition Width="100" />
            <ColumnDefinition Width="100" />
            <ColumnDefinition Width="100" />
            <ColumnDefinition Width="100" />
        </Grid.ColumnDefinitions>
        <Border
            Background="DeepSkyBlue"
            Grid.Column="{Binding SelectionIndex, RelativeSource={RelativeSource AncestorType=UserControl}}"
            >
        </Border>
        <Label Grid.Column="0">Click Me</Label>
        <Label Grid.Column="1">No, Click Me</Label>
        <Label Grid.Column="2">Me Me Me!</Label>
        <Label Grid.Column="3">Wahhhh</Label>
    </Grid>
