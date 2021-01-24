    <ListBox ItemsSource="{Binding Items}">
        <ListBox.ItemContainerStyle>
            <Style TargetType="ListBoxItem">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="ListBoxItem">
                            <TextBlock Text="{Binding SelectedOption}"/>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <Trigger Property="IsSelected" Value="True">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="ListBoxItem">
                                    <ComboBox ItemsSource="{Binding Options}"
                                              SelectedItem="{Binding SelectedOption}"/>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </ListBox.ItemContainerStyle>
    </ListBox>
