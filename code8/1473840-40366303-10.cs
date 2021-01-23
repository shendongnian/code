    <Style x:Key="MyCustomStyle" TargetType="{x:Type TabControl}">
        <Style.Resources>
            <local:TabItemHeaderConverter x:Key="TabItemHeaderConverter" />
            <Style TargetType="{x:Type TabItem}">
                <Setter Property="Padding" Value="10"/>
                <Setter Property="Width" Value="120"/>
                <Setter Property="ContentTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <StackPanel Margin="10">
                                <Label 
                                    FontSize="20" 
                                    >
                                    <Label.Content>
                                        <MultiBinding Converter="{StaticResource TabItemHeaderConverter}">
                                            <Binding RelativeSource="{RelativeSource AncestorType=TabControl}" />
                                            <Binding Path="." />
                                        </MultiBinding>
                                    </Label.Content>
                                </Label>
                                <Separator />
                                <ContentControl 
                                    Content="{Binding}"
                                />
                            </StackPanel>
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Style.Resources>
        <Setter Property="TabStripPlacement" Value="Left"/>
    </Style>
