    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <ListBox Name="listbox">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Name}"></TextBlock>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
        <Image Source="{Binding ElementName=listbox,Path=SelectedItem.URL}" Height="300"/>
        <Button Name="btnClick" Click="btnClick_Click">Click Me</Button>
    </Grid>
