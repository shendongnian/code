    <Grid DataContext="{Binding RelativeSource={RelativeSource AncestorType=UserControl}}">
        <TabControl ItemsSource="{Binding Tabs}">
            <TabControl.ContentTemplate>
                <DataTemplate>
                    <DataTemplate.Resources>
                        <local:SomeDetail x:Key="SomeDetailControl" x:Shared="False"  Prop="{Binding PropValue}" PropTwo="{Binding PropTwoValue}" />
                    </DataTemplate.Resources>
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
                                        <Setter Property="Content" Value="{StaticResource SomeDetailControl}" />
                                    </DataTrigger>
                                </Style.Triggers>
                            </Style>
                        </ContentControl.Style>
                    </ContentControl>
                </DataTemplate>
            </TabControl.ContentTemplate>
        </TabControl>
    </Grid>
