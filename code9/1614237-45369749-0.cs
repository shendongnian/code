    <ComboBox Grid.Row="1" Name="MyComboBox" Width="200">
            <ComboBox.Resources>
                <Style TargetType="ContentPresenter">
                    <Setter Property="RenderTransform">
                        <Setter.Value>
                            <TranslateTransform X="0" Y="0" />
                        </Setter.Value>
                    </Setter>
                    <Style.Triggers>
                        <EventTrigger RoutedEvent="Window.Loaded">
                            <EventTrigger.Actions>
                                <BeginStoryboard x:Name="ScrollItem">
                                    <Storyboard RepeatBehavior="Forever">
                                        <DoubleAnimation Duration="00:00:5" From="0" To="200" Storyboard.TargetProperty="RenderTransform.(TranslateTransform.X)" />
                                        <DoubleAnimation Duration="00:00:5" BeginTime="00:00:5" From="-200" To="0" Storyboard.TargetProperty="RenderTransform.(TranslateTransform.X)" />
                                    </Storyboard>
                                </BeginStoryboard>
                            </EventTrigger.Actions>
                        </EventTrigger>
                    </Style.Triggers>
                </Style>
            </ComboBox.Resources>
            <ComboBoxItem>
                I am combobox value 1
            </ComboBoxItem>
            <ComboBoxItem>
                I am combobox value 2, Hello!
            </ComboBoxItem>
        </ComboBox>
