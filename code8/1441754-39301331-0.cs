    <Style TargetType="TabItem" x:Name="MyTab">
        <Setter Property="MinHeight" Value="35" />
        <Setter Property="MinWidth" Value="105" />
                    <!-- 3 -->
        <Setter Property="Background" Value="#424f5a" />
        <!--Template-->
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="TabItem">
                                                <!-- 2 -->
                    <Grid Name="Panel" Background="{TemplateBinding Background}" TextBlock.Foreground="#e8e8e8">
                        <Border Name="Border">
                            <ContentPresenter x:Name="ContentSite"
                        VerticalAlignment="Center" HorizontalAlignment="Center"
                        ContentSource="Header" Margin="10,2"/>
                        </Border>
                    </Grid>
                    <ControlTemplate.Triggers>
                        <!-- Selected state-->
                        <Trigger Property="IsSelected" Value="True">
                                        <!-- 4 -->
                            <Setter TargetName="Panel" Property="Background" Value="#383838" />
                            <Setter Property="Foreground" Value="#fbfbfb"/>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
        <!-- 1 -->
        <Style.Triggers>
            <EventTrigger RoutedEvent="MouseEnter">
                <EventTrigger.Actions>
                    <BeginStoryboard >
                        <Storyboard>
                            <ColorAnimation  Duration="0:0:0.1" To="#5e6972" Storyboard.TargetProperty="Background.(SolidColorBrush.Color)"/>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger.Actions>
            </EventTrigger>
            <!-- Mouse leave -->
            <EventTrigger RoutedEvent="MouseLeave">
                <EventTrigger.Actions>
                    <BeginStoryboard>
                        <Storyboard>
                            <ColorAnimation  Duration="0:0:0.1" To="#424f5a" Storyboard.TargetProperty="Background.(SolidColorBrush.Color)"/>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger.Actions>
            </EventTrigger>
        </Style.Triggers>
    </Style>
