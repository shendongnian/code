`
 <ScrollViewer>
            <ItemsControl ItemsSource="{Binding Images}">
                <ItemsControl.Template>
                    <ControlTemplate>
                        <Grid
                            IsItemsHost="True"
                            Loaded="Grid_Loaded"
                            GridHelpers.RowCount="{Binding Path=Items.Count, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type ItemsControl}}}">
                        </Grid>
                    </ControlTemplate>
                </ItemsControl.Template>
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <materialDesign:Card Padding="32px" Margin="8px">
                            <StackPanel>
                                <StackPanel>
                                    <Image Source="{Binding Path, Mode=OneWay}" />
                                </StackPanel>
                            </StackPanel>
                        </materialDesign:Card>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
   </ScrollViewer>
`
