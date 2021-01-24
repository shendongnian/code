    <ItemsControl Name="ItemsDisplay">
        <ItemsControl.Resources>
            <local:MyMultiConv x:Key="MyConv"/>
        </ItemsControl.Resources>
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <Grid>
                            <!-- COLUMN DEFINITIONS ETC REMOVED TO SHORTEN -->
                            <StackPanel Grid.Column="1">
                                <Label Name="ItemName" Margin="10">
                                    <Label.Content>
                                        <MultiBinding  Converter="{StaticResource MyConv}">
                                            <Binding Path="name" />
                                            <Binding Path="typeLine" />
                                        </MultiBinding>
                                    </Label.Content>
                                </Label>
                            </StackPanel>
                        </Grid>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
    </ItemsControl>
