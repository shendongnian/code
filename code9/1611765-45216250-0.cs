    <ContentControl Content="{Binding ElementName=MyItems, Path=SelectedItem}">
        <ContentControl.Resources>
            <DataTemplate DataType="{x:Type local:ObjectOne}">
                <StackPanel>
                    <TextBox Text="{Binding Prop1}"/>
                    <TextBox Text="{Binding Prop2}"/>
                </StackPanel>
            </DataTemplate>
            <DataTemplate DataType="{x:Type local:ObjectTwo}">
                <StackPanel>
                    <TextBox Text="{Binding Prop1}"/>
                    <TextBox Text="{Binding Prop2}"/>
                    <TextBox Text="{Binding Prop3}"/>
                </StackPanel>
            </DataTemplate>
        </ContentControl.Resources>
    </ContentControl>
