     <ListView  x:Name="ListView"
                                ItemsSource="{x:Bind ViewModel.SampleItems, Mode=OneWay}"
                                SelectedItem="{x:Bind ViewModel.SelectedItem, Mode=OneWay}"
                                IsItemClickEnabled="True">
                            <i:Interaction.Behaviors>
                                <ic:EventTriggerBehavior EventName="ItemClick">
                                    <ic:InvokeCommandAction Command="{x:Bind ViewModel.ItemClickCommand}" />
                                </ic:EventTriggerBehavior>
                            </i:Interaction.Behaviors>
                            
                        </ListView>
