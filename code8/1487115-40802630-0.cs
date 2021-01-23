    <RadioButton Content="Boom" IsEnabled="{Binding IsChecked, Converter={StaticResource InverseBooleanConverter}, RelativeSource={RelativeSource Mode=Self}}">
     <i:Interaction.Triggers>
            <i:EventTrigger EventName="Checked">
                <i:InvokeCommandAction Command="{Binding MyCommand}" />
            </i:EventTrigger>
        </i:Interaction.Triggers>
    </RadioButton>
