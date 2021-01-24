    <Style TargetType="ListBoxItem">
        <Setter Property="IsSelected" Value="{Binding Content.IsSelected, Mode=TwoWay, RelativeSource={RelativeSource Self}}"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="ListBoxItem">
                    <ContentPresenter/>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
