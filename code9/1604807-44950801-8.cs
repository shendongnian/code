    <ComboBox 
        SelectedValue="{Binding LanguageId}" 
        ItemsSource="{Binding Languages}"
        >
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <Label>
                    <Label.Content>
                        <MultiBinding 
                            Converter="{StaticResource LanguageNameConverter}"
                            >
                            <Binding Path="." />
                            <Binding 
                                Path="DataContext.LanguageId" 
                                RelativeSource="{RelativeSource AncestorType=ComboBox}" 
                                />
                        </MultiBinding>
                    </Label.Content>
                </Label>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
