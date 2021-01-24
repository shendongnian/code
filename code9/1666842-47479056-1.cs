    <ListView.GroupStyle>
        <GroupStyle>
            <GroupStyle.ContainerStyle>
                <Style TargetType="{x:Type GroupItem}">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate>
                                <Expander IsExpanded="True">
                                    <Expander.Header>
                                        <StackPanel Orientation="Horizontal">
                                            <TextBlock Text="{Binding Items[0].Pattern, StringFormat={} Teste: {0}}" FontWeight="Bold" Foreground="Gray" FontSize="22" VerticalAlignment="Bottom" />
                                            <Border CornerRadius="10" Padding="1,1,1,1" BorderThickness="1" BorderBrush="Black" Background="Red" Margin="1,0,0,0" >
                                                <TextBlock Text="{Binding Items.Count,StringFormat={} Items: {0}}" Padding="0" VerticalAlignment="Center"  Margin="5,1,5,1" FontSize="15" FontWeight="Bold" Foreground="Black"/>                                                        
                                            </Border>
                                        </StackPanel>
                                    </Expander.Header>
                                    <ListView ItemsSource="{TemplateBinding Items}">
                                             <ListView.View>
                                                 <GridView>
                                                     <GridViewColumn Header="Linha" Width="Auto" DisplayMemberBinding="{Binding LineNumber}" />
                                                     <GridViewColumn Header="Fonte" Width="Auto" DisplayMemberBinding="{Binding Source}" />
                                                     <GridViewColumn Header="Data" Width="Auto" DisplayMemberBinding="{Binding Time}" />
                                                     <GridViewColumn Header="Log" Width="Auto" DisplayMemberBinding="{Binding LineLog}" />
                                                 </GridView>
                                              </ListView.View>
                                    </ListView>
                                </Expander>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </GroupStyle.ContainerStyle>
        </GroupStyle>
    </ListView.GroupStyle>
