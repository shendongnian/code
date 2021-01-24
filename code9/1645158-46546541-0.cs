    <DataTemplate DataType="{x:Type config:ElementGroup}">
        <DataTemplate.Resources>
            <Style TargetType="{x:Type GroupBox}">
                <Setter Property="Foreground" Value="{StaticResource TextColor}" />
                <Setter Property="Header" Value="{Binding Path=ItemLabel}" />
                <Setter Property="Margin" Value="5,0,5,0" />
            </Style>
        </DataTemplate.Resources>
        <Grid>
            <GroupBox x:Name="gb">
                <ItemsControl ItemsSource="{Binding Path=ElementList}" Visibility="Visible">
                    <ItemsControl.ItemsPanel>
                        <ItemsPanelTemplate>
                            <UniformGrid Columns="{Binding Path=Columns}" />
                        </ItemsPanelTemplate>
                    </ItemsControl.ItemsPanel>
                </ItemsControl>
            </GroupBox>
            <ItemsControl x:Name="ic" ItemsSource="{Binding Path=ElementList}" Visibility="Collapsed">
                <ItemsControl.ItemsPanel>
                    <ItemsPanelTemplate>
                        <UniformGrid Columns="{Binding Path=Columns}" />
                    </ItemsPanelTemplate>
                </ItemsControl.ItemsPanel>
            </ItemsControl>
        </Grid>
        <DataTemplate.Triggers>
            <DataTrigger Binding="{Binding Path=HideBorder}" Value="True">
                <Setter TargetName="gb" Property="Visibility" Value="Collapsed" />
                <Setter TargetName="ic" Property="Visibility" Value="Visible" />
            </DataTrigger>
        </DataTemplate.Triggers>
    </DataTemplate>
