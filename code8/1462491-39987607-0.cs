    <ContextMenu ItemsSource="{Binding Path=ContextMenu.Items}">
      <ContextMenu.ItemTemplate>
        <DataTemplate>
          <ContentControl>
            <MenuItem Command="{Binding}"
                      CommandParameter="{Binding ContextMenu.ContextItem
                          RelativeSource={RelativeSource AncestorType=ContextMenu}}"/>
          </ContentControl>
        </DataTemplate>
      </ContextMenu.ItemTemplate>
    </ContextMenu>
