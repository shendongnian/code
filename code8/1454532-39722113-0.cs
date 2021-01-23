            <ListView x:Name="ApplicationList" ClipToBounds="True" Margin="0,100">
                <ListView.View>
                    <GridView x:Name="ApplicationListGrid">
                        <GridViewColumn>
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <Grid>
                                        <Grid.ColumnDefinitions>
                                            <ColumnDefinition></ColumnDefinition>
                                            <ColumnDefinition></ColumnDefinition>
                                        </Grid.ColumnDefinitions>
                                        <CheckBox Grid.Column="0" Tag="{Binding Check}" IsChecked="{Binding Check}"/>
                                        <ProgressBar  Grid.Column="1" Maximum="100" Value="{Binding Progress}"/>
                                    </Grid>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn Header="Application Name" Width="250" DisplayMemberBinding="{Binding Name}" />
                        <GridViewColumn Header="Application Description" Width="300" DisplayMemberBinding="{Binding Description}" />
                    </GridView>
                </ListView.View>
            </ListView>
