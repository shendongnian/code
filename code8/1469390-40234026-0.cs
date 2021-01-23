    <Image x:Name="myImage" Source="{Binding SmallUri}" Stretch="UniformToFill">
        <Image.Triggers>
            <EventTrigger RoutedEvent="Image.Loaded">
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation Storyboard.TargetProperty="Opacity" From="0" To="1" Duration="00:00:5" Storyboard.TargetName="myImage" />
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </Image.Triggers>
    </Image>
