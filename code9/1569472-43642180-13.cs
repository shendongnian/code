    <ContentControl>
        <ContentControl.Style>
            <Style TargetType="ContentControl">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Status}" Value="NotFound">
                        <Setter Property="ContentTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                    <TextBlock Text="Not found" />
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding Status}" Value="ConnectionError">
                        <Setter Property="ContentTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                    <Button Content="Connection error. Try again?" />
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding Status}" Value="Loaded">
                        <Setter Property="ContentTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                    <Ellipse
                                        Height="32"
                                        Width="32"
                                        Fill="DeepSkyBlue"
                                        />
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ContentControl.Style>
    </ContentControl>
