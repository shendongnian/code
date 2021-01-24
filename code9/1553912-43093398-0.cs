    <UserControl ...>
        <UserControl.Resources>
            <ResourceDictionary>
                <ResourceDictionary.MergedDictionaries>
                    <ResourceDictionary Source="pack://application:,,,/WPFUserControls;component/Styles/BaseSliderStyle.xaml"/>
                </ResourceDictionary.MergedDictionaries>
            </ResourceDictionary>
        </UserControl.Resources>
        <Grid>
            <Slider x:Name="Hello" Style="{StaticResource BaseSliderStyle}" Value="{Binding Value, Mode=TwoWay, 
                        RelativeSource={RelativeSource AncestorType={x:Type local:CustomSlider}}}" Minimum="0.0" Maximum="1.0"/>
        </Grid>
    </UserControl>
