    <ComboBox Name="ComboVeh" ItemsSource="{Binding Veh}" >
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="SelectionChanged">
                <i:InvokeCommandAction Command="{Binding UpdateCommand}"
                                               CommandParameter="{Binding SelectedValue, ElementName=ComboVeh}" />
            </i:EventTrigger>
        </i:Interaction.Triggers>
    </ComboBox>
    <ContentControl Content="{Binding SelectedValue, ElementName=ComboVeh}">
        <ContentControl.Style>
            <Style TargetType="ContentControl">
                <Setter Property="ContentTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <ComboBox Name="ComboVehTypes" ItemsSource="{Binding DataContext.VehTypes, RelativeSource={RelativeSource AncestorType=ContentControl}}"/>
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <Trigger Property="Content" Value="Other">
                        <Setter Property="ContentTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                    <TextBox />
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </ContentControl.Style>
    </ContentControl>
