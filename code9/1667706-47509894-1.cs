    <Window.Resources>
        <CollectionViewSource x:Key="cvs" Source="{Binding Artifacts}">
            <CollectionViewSource.GroupDescriptions>
                <PropertyGroupDescription PropertyName="FileType" />
            </CollectionViewSource.GroupDescriptions>
        </CollectionViewSource>
    </Window.Resources>
    ...
    <ItemsControl ItemsSource="{Binding Source={StaticResource cvs}}">
        <ItemsControl.GroupStyle>
            <GroupStyle>
                <GroupStyle.Panel>
                    <ItemsPanelTemplate>
                        <WrapPanel Orientation="Horizontal" IsItemsHost="True"/>
                    </ItemsPanelTemplate>
                </GroupStyle.Panel>
                <GroupStyle.HeaderTemplate>
                    <DataTemplate>
                        <Label Content="{Binding Name}" />
                    </DataTemplate>
                </GroupStyle.HeaderTemplate>
            </GroupStyle>
        </ItemsControl.GroupStyle>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Image Source="{Binding Path}"/>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
