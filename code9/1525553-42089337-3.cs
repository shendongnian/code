     <Window.Resources>
        <local:BackConverter x:Key="BackConverter"/>
    </Window.Resources>
    <Grid Margin="10">
        <ItemsControl Name="ic"> 
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <DockPanel LastChildFill="False">
                   <DockPanel.Background>
                                <MultiBinding Converter="{StaticResource BackConverter}">
                                    <Binding />
                                    <Binding RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType=ItemsControl}"/>
                                </MultiBinding>
                            </DockPanel.Background>
                        <TextBlock DockPanel.Dock="Left" Text="{Binding Left}">
                        </TextBlock>
                        <TextBlock DockPanel.Dock="Right" Text="{Binding Right}">
                        </TextBlock>
                    </DockPanel>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Grid>
