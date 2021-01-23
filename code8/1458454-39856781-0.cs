    <Label Content="{Binding}" Width="250" />
    <ContentControl>
            <Style TargetType="ContentControl">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding ...}" Value="True">
                        <Setter Property="Content">
                            <Setter.Value>
                                <Button Content="+" .../>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding ...}" Value="False">
                        <Setter Property="Content">
                            <Setter.Value>
                                <Button Content="-" .../>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
    </ContentControl>
