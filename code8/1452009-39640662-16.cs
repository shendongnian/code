    <ControlTemplate TargetType="{x:Type ListViewItem}">
        <StackPanel>
            <Canvas Width="15" Height="100">
                <Rectangle x:Name="Highlight"  Width="60" Height="5" Canvas.Top="105"/>
                <ContentPresenter x:Name="CardPresenter">
                    <ContentPresenter.RenderTransform>
                        <TransformGroup>
                            <TranslateTransform x:Name="TranslateTransformHighlight"/>
                            <RotateTransform x:Name="RotateTransformHighlight" CenterY="100"/>
                            <TranslateTransform x:Name="TranslateTransformSelect"/>
                        </TransformGroup>
                    </ContentPresenter.RenderTransform>
                </ContentPresenter>
            </Canvas>
        </StackPanel>
        <ControlTemplate.Triggers>
            <Trigger Property="IsMouseOver" Value="True" >
                <Trigger.EnterActions>
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation Storyboard.TargetName="TranslateTransformHighlight" Duration="0:0:0.200" To="-5" Storyboard.TargetProperty="Y" />
                            <DoubleAnimation Storyboard.TargetName="RotateTransformHighlight" Duration="0:0:0.200" To="-5" Storyboard.TargetProperty="Angle" />
                        </Storyboard>
                    </BeginStoryboard>
                </Trigger.EnterActions>
                <Trigger.ExitActions>
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation Storyboard.TargetName="TranslateTransformHighlight" Duration="0:0:0.200" To="0" Storyboard.TargetProperty="Y" />
                            <DoubleAnimation Storyboard.TargetName="RotateTransformHighlight" Duration="0:0:0.200" To="0" Storyboard.TargetProperty="Angle" />
                        </Storyboard>
                    </BeginStoryboard>
                </Trigger.ExitActions>
            </Trigger>
            <Trigger Property="IsSelected" Value="True">
                <Setter TargetName="Highlight" Property="Fill" Value="Yellow"/>
                <Trigger.EnterActions>
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation Storyboard.TargetName="TranslateTransformSelect" Duration="0:0:0.200" To="-15" Storyboard.TargetProperty="Y" />
                        </Storyboard>
                    </BeginStoryboard>
                </Trigger.EnterActions>
                <Trigger.ExitActions>
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation Storyboard.TargetName="TranslateTransformSelect" Duration="0:0:0.200" To="0" Storyboard.TargetProperty="Y" />
                        </Storyboard>
                    </BeginStoryboard>
                </Trigger.ExitActions>
            </Trigger>
        </ControlTemplate.Triggers>
    </ControlTemplate>
