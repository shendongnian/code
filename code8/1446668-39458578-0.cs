    <DataGridComboBoxColumn Header="{StaticResource XpStrColor}" SelectedValueBinding="{Binding ColorIndex}" 
            SelectedValuePath="Index" DisplayMemberPath="Index">
        <DataGridComboBoxColumn.ElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type UserControl}}, Path=DataContext.Colors}"/>
                <Setter Property="IsReadOnly" Value="True"/>
                <Setter Property="ItemTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <WrapPanel>
                                <Rectangle Height="10" Width="80">
                                    <Rectangle.Fill>
                                        <SolidColorBrush Color ="{Binding Converter={StaticResource ColorIndexToColorConverter}}"/>
                                    </Rectangle.Fill>
                                </Rectangle>
                            </WrapPanel>
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </DataGridComboBoxColumn.ElementStyle>
        <DataGridComboBoxColumn.EditingElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type UserControl}}, Path=DataContext.Colors}"/>
                <Setter Property="ItemTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <WrapPanel>
                                <Rectangle Height="10" Width="80">
                                    <Rectangle.Fill>
                                        <SolidColorBrush Color ="{Binding Converter={StaticResource ColorIndexToColorConverter}}"/>
                                    </Rectangle.Fill>
                                </Rectangle>
                            </WrapPanel>
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </DataGridComboBoxColumn.EditingElementStyle>
    </DataGridComboBoxColumn>
