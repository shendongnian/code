    <c:MyRichTextBox>
        <c:MyRichTextBox.Style>
            <Style TargetType="c:MyRichTextBox" BasedOn="{StaticResource MyRichTextBoxStyle}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="c:MyRichTextBox">
                            <StackPanel>
                                <ItemsControl ItemsSource="{TemplateBinding EditingCommands}" HorizontalAlignment="Right">
                                    <ItemsControl.ItemsPanel>
                                        <ItemsPanelTemplate>
                                            <StackPanel Orientation="Horizontal" />
                                        </ItemsPanelTemplate>
                                    </ItemsControl.ItemsPanel>
                                </ItemsControl>
                                <RichTextBox />
                            </StackPanel>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </c:MyRichTextBox.Style>
    </c:MyRichTextBox>
