    <ItemsControl ItemsSource="{Binding Path=Children}">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <ContentControl Content="{Binding}">
                        <ContentControl.ContentTemplate>
                            <DataTemplate>
                                <ContentPresenter Content="{Binding Preview}"/>
                            </DataTemplate>
                        </ContentControl.ContentTemplate>
                    </ContentControl>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
