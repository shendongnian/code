    <Style TargetType="{x:Type DataGridCell}">
        <Style.Triggers>
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <Condition Binding="{Binding DataContext.IsTopElement, RelativeSource={RelativeSource AncestorType=UserControl}}" Value="False"/>
                    <Condition Binding="{Binding IsCustomer}" Value="True"/>
                </MultiDataTrigger.Conditions>
                <Setter Property="IsEnabled" Value="False"/>
            </MultiDataTrigger>
        </Style.Triggers>
    </Style>
