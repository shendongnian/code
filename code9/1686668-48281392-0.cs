    <ListBox x:Name="MessagesLb" Grid.Column="1" Margin="241,100,22.4,50" Grid.Row="1" BorderThickness="0" FontSize="14" FontWeight="SemiBold" 
             ItemsSource="{Binding Items}" SelectionMode="Extended">
        <ListBox.Resources>
            <ContextMenu x:Key="cm">
                <MenuItem Header="Copia" Click="MessagesLbCopySubMi_Click" />
                <Separator/>
                <MenuItem Header="Dettagli" />
            </ContextMenu>
        </ListBox.Resources>
        <ListBox.ItemContainerStyle>
            <Style TargetType="ListBoxItem">
                <Setter Property="ContextMenu" Value="{StaticResource cm}" />
                <Style.Triggers>
                    <DataTrigger Binding="{Binding SelectedItems.Count, RelativeSource={RelativeSource AncestorType={x:Type ListBox}}}" Value="0">
                        <Setter Property="ContextMenu" Value="{x:Null}" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ListBox.ItemContainerStyle>
        <ListBox.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding}" HorizontalAlignment="Center" VerticalAlignment="Center" />
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
