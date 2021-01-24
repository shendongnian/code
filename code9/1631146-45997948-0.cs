    <Grid DataContext="{Binding RelativeSource={RelativeSource AncestorType=UserControl}}">
        <TabControl ItemsSource="{Binding Tabs}">
            <TabControl.ContentTemplate>
                <DataTemplate>
                    <ContentControl>
                        <ContentControl.Style>
                            <Style TargetType="ContentControl">
                                <Setter Property="Content">
                                    <Setter.Value>
                                        <TextBlock>default template...</TextBlock>
                                    </Setter.Value>
                                </Setter>
                                <Style.Triggers>
                                    <DataTrigger Binding="{Binding MyBinding}" Value="True">
                                        <Setter Property="Content">
                                            <Setter.Value>
                                                <local:SomeDetail x:Key="SomeDetailControl" Prop="{Binding PropValue}" PropTwo="{Binding PropTwoValue}" />
                                            </Setter.Value>
                                        </Setter>
                                    </DataTrigger>
                                </Style.Triggers>
                            </Style>
                        </ContentControl.Style>
                    </ContentControl>
                </DataTemplate>
            </TabControl.ContentTemplate>
        </TabControl>
    </Grid>
