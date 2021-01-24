    <Page.Resources>
                <local:MultiIcommandParameterConverter x:Key="MultiIcommandParameterConverter"></local:MultiIcommandParameterConverter>
        </Page.Resources>
     <ItemsControl>
                                <ItemsControl.ItemsPanel>
                                    <ItemsPanelTemplate>
                                        <WrapPanel></WrapPanel>
                                    </ItemsPanelTemplate>
                                </ItemsControl.ItemsPanel>
                                <ItemsControl.ItemTemplate>
                                    <DataTemplate>
                                        <Button Command="{Binding ButtonClick}">
                                            <Button.CommandParameter>
                                                <MultiBinding Converter="{StaticResource MultiIcommandParameterConverter}">
                                                    <Binding Path="DetailIndex"/>
                                                    <Binding Path="DetailContent"/>
                                                </MultiBinding>
                                            </Button.CommandParameter>                                       
                                        </Button>
                                    </DataTemplate>
                                </ItemsControl.ItemTemplate>
                            </ItemsControl>
