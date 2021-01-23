    <ItemsControl Background="Transparent" 
                ItemsSource="{Binding Source={StaticResource SomeCollectionView}}">
            <ItemsControl.Resources>
                <DataTemplate x:Key="FullViewTemplate">
                    <Border >
                        <Label Content="{Binding}"
                                                  />
                    </Border>
                </DataTemplate>
                <DataTemplate x:Key="CompactViewTemplate">
                    <Border >
                        <Button Content="{Binding}"
                                                    />
                    </Border>
                </DataTemplate>
            </ItemsControl.Resources>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <ContentControl Content="{Binding}">
                        <ContentControl.Style>
                            <Style TargetType="{x:Type ContentControl}">
                                <Setter Property="ContentTemplate" Value="{StaticResource FullViewTemplate}"/>
                                <Style.Triggers>
                                    <DataTrigger Binding="{Binding RelativeSource={RelativeSource AncestorType=Window}, Path=DataContext.ShowCompactView}" Value="True">
                                        <Setter Property="ContentTemplate" Value="{StaticResource CompactViewTemplate}"/>
                                    </DataTrigger>
                                </Style.Triggers>
                            </Style>
                        </ContentControl.Style>
                    </ContentControl>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
