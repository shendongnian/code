    <ComboBox
        ItemsSource="{Binding Source={StaticResource VendorsCollection}}"
        IsEditable="True">
        <ComboBox.Style>
            <Style TargetType="ComboBox">
                <Style.Triggers>
                    <Trigger Property="Text" Value="">
                        <Setter Property="Background">
                            <Setter.Value>
                                <VisualBrush AlignmentX="Left" Stretch="None">
                                    <VisualBrush.Visual>
                                        <Grid Background="White">
                                            <TextBlock Margin="4 3" Text="Select a vendor"/>
                                        </Grid>
                                    </VisualBrush.Visual>
                                </VisualBrush>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </ComboBox.Style>
    </ComboBox>
