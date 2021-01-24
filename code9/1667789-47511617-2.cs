    <foo:DynamicTabControl x:Name="testTabContr" ItemsSource="{Binding data}">
        <foo:DynamicTabControl.TabContentTemplate>
            <DataTemplate>
                <TextBox Text="{Binding someData}"/>
            </DataTemplate>
        </foo:DynamicTabControl.TabContentTemplate>
    </foo:DynamicTabControl>
