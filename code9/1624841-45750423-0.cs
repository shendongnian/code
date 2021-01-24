     <ContentControl>
                    <ContentControl.Style>
                        <Style TargetType="ContentControl">
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding IsLink}" Value="True">
                                    <Setter Property="ContentTemplate"  >
                                        <Setter.Value>
                                            <DataTemplate>
                                                <TextBlock>
                                                     <Hyperlink  NavigateUri="{Binding DataContext.Url, RelativeSource={RelativeSource Mode=FindAncestor,      
                            AncestorType= ContentControl} }">
                                                        <TextBlock Text="{Binding DataContext.DisplayText, RelativeSource={RelativeSource Mode=FindAncestor,      
                            AncestorType=ContentControl} }"/>
                                                    </Hyperlink>
                                                </TextBlock>
                                            </DataTemplate>
                                        </Setter.Value>
                                    </Setter>
                                </DataTrigger>
                                <DataTrigger Binding="{Binding IsLink}" Value="False">
                                    <Setter Property="ContentTemplate" >
                                        <Setter.Value>
                                            <DataTemplate>
                                                <TextBlock Text="{Binding DataContext.DisplayText,RelativeSource={RelativeSource Mode=FindAncestor,      
                            AncestorType=ContentControl} }"/>
                                            </DataTemplate>
                                        </Setter.Value>
                                    </Setter>
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </ContentControl.Style>
                </ContentControl>
