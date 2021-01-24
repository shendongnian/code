    <ContentControl Content="{Binding MyViewModel}">
        <ContentControl.Resources>
            <DataTemplate DataType="{x:Type viewModel:ViewModel1}">
                <view:View1 />
            </DataTemplate>
            <DataTemplate DataType="{x:Type viewModel:ViewModel2}">
                <view:View2 />
            </DataTemplate>
        </ContentControl.Resources>
    </ContentControl>
