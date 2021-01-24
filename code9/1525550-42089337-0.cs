     <Window.Resources>
        <local:BackConverter x:Key="BackConverter"/>
    </Window.Resources>
    <Grid Margin="10">
        <ItemsControl Name="ic"> 
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <DockPanel LastChildFill="False">
                        <TextBlock DockPanel.Dock="Left" Text="{Binding Left}">
                            <TextBlock.Background>
                                <MultiBinding Converter="{StaticResource BackConverter}">
                                    <Binding />
                                    <Binding RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType=ItemsControl}"/>
                                </MultiBinding>
                            </TextBlock.Background>
                        </TextBlock>
                        <TextBlock DockPanel.Dock="Right" Text="{Binding Right}">
                            <TextBlock.Background >
                                <MultiBinding Converter="{StaticResource BackConverter}">
                                    <Binding />
                                    <Binding RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType=ItemsControl}"/>
                                </MultiBinding>
                            </TextBlock.Background>
                        </TextBlock>
                    </DockPanel>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Grid>
