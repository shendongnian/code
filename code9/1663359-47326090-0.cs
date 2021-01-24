    <Grid x:Name="PopUp" Visibility="{Binding ShowPopUp, Converter={StaticResource BoolToVisibilityConverter}}">
            <Grid.ColumnDefinitions> 
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="Auto"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
            <ContentControl Grid.Row="1" Grid.Column="1">
                <ContentControl.Style>
                    <Style TargetType="ContentControl">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding ShowView1}" Value="true">
                                <Setter Property="Template">
                                    <Setter.Value>
                                        <ControlTemplate>
                                            <Border>
                                                <view:View1/>
                                            </Border>
                                        </ControlTemplate>
                                    </Setter.Value>
                                </Setter>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </ContentControl.Style>
            </ContentControl>
        </Grid>
