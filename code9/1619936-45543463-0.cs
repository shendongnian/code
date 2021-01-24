    <Border BorderBrush="{DynamicResource MaterialDesignDivider}">
        <RadioButton IsChecked="{Binding Erase_IsSelected}" Content="E">
            <RadioButton.Style>
                <Style TargetType="{x:Type RadioButton}">
                    <Style.Triggers>
                        <Trigger Property="IsChecked" Value="True">
                            <Setter Property="Background" Value="{DynamicResource MaterialDesignSelection}" />
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </RadioButton.Style>
        </RadioButton>
    </Border>
