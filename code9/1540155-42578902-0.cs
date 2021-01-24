    <Style TargetType="Image">
        <Style.Triggers>
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <Condition Binding="{Binding IsMouseOver, RelativeSource={RelativeSource Self}}" Value="True" />
                    <Condition Binding="{Binding Picture, Converter={StaticResource IsImageNullConverter}}" Value="False" />
                </MultiDataTrigger.Conditions>
            </MultiDataTrigger>
        </Style.Triggers>
    </Style>
