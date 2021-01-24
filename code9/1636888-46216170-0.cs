    <Style BasedOn="{StaticResource SomeGlobalStaticStyle}" TargetType="Label">
        <Style.Triggers>
            <DataTrigger Binding="{Binding PersonModel.PerformanceFormat}" Value="Fractional">
                <Setter Property="Content"  Value="{Binding Tag.Performance.Value.Fractional, RelativeSource={RelativeSource Self}}}"  />
            </DataTrigger>
            <DataTrigger Binding="{Binding PersonModel.PerformanceFormat}" Value="Decimal">
                <Setter Property="Content"  Value="{Binding Tag.Performance.Value.Decimal, RelativeSource={RelativeSource Self}}" />
            </DataTrigger>
            <DataTrigger Binding="{Binding PersonModel.PerformanceFormat}" Value="US">
                <Setter Property="Content"  Value="{Binding Tag.Performance.Value.US, RelativeSource={RelativeSource Self}}}" />
            </DataTrigger>
        </Style.Triggers>
    </Style>
