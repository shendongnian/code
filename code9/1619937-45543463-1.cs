    <Border BorderBrush="{DynamicResource MaterialDesignDivider}">
        <Border.Style>
            <Style TargetType="Border">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsChecked, ElementName=rb}" Value="True">
                        <Setter Property="Background" Value="{DynamicResource MaterialDesignSelection}" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Border.Style>
        <RadioButton x:Name="rb" IsChecked="{Binding Erase_IsSelected}" Content="E" />
    </Border>
