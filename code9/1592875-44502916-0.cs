    <ItemsControl ...>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding DataContext.SelectedMember.MEMBERINFO.MEMBER_NAME, 
                            RelativeSource={RelativeSource AncestorType=ItemsControl}}" />
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
