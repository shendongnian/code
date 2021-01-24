    <Window.Resources>
        <Style TargetType="WrapPanel" x:Key="WrapForm">
            <Setter Property="Orientation" Value="Horizontal" />
            <Setter Property="Grid.IsSharedSizeScope" Value="True" />
            <Style.Resources>
                <!-- Implicit style for all HeaderedContentControls -->
                <Style TargetType="HeaderedContentControl">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="HeaderedContentControl">
                                <Grid>
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition Width="Auto" SharedSizeGroup="LabelCol" />
                                        <ColumnDefinition Width="120" SharedSizeGroup="InputCol" />
                                    </Grid.ColumnDefinitions>
                                    <Label
                                        VerticalContentAlignment="Top"
                                        Grid.Column="0"
                                        Content="{TemplateBinding Header}" 
                                        />
                                    <ContentControl
                                        VerticalContentAlignment="Top"
                                        Grid.Column="1"
                                        Content="{TemplateBinding Content}"
                                        />
                                </Grid>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </Style.Resources>
        </Style>
    </Window.Resources>
    <Grid>
        <WrapPanel Style="{StaticResource WrapForm}">
            <HeaderedContentControl Header="Regular Paid Hours">
                <TextBox />
            </HeaderedContentControl>
            <HeaderedContentControl Header="Overtime Hours">
                <TextBox />
            </HeaderedContentControl>
            <HeaderedContentControl Header="Repair Labor">
                <ComboBox HorizontalAlignment="Left" />
            </HeaderedContentControl>
            <HeaderedContentControl Header="This One Has Two">
                <StackPanel Orientation="Vertical">
                    <CheckBox>One Thing</CheckBox>
                    <CheckBox>Or Another</CheckBox>
                </StackPanel>
            </HeaderedContentControl>
        </WrapPanel>
    </Grid>
