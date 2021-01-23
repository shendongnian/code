    <Style TargetType="StackPanel" x:Key="expand">
        <Setter Property="Width" Value="48"></Setter>
    
        <Style.Triggers>
    
            <!--TO EXPAND-->
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <Condition Binding="{Binding IsPressed, ElementName=btnExpandirMenu,PresentationTraceSources.TraceLevel=High}" Value="True" />
                    <Condition Binding="{Binding Width, ElementName=menuLateral,PresentationTraceSources.TraceLevel=High, UpdateSourceTrigger=PropertyChanged}" Value="48" />
                </MultiDataTrigger.Conditions>
                <MultiDataTrigger.EnterActions>
                    <StopStoryboard BeginStoryboardName="OUT"/>
                    <BeginStoryboard Name="IN">
                        <Storyboard>
                            <DoubleAnimation Storyboard.TargetProperty="Width" To="358" Duration="0:00:0.2"/>
                        </Storyboard>
                    </BeginStoryboard>
                </MultiDataTrigger.EnterActions>
            </MultiDataTrigger>
            <!--TO CLOSE-->
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <Condition Binding="{Binding IsPressed, ElementName=btnExpandirMenu}" Value="True"/>
                    <Condition Binding="{Binding ActualWidth, ElementName=menuLateral}" Value="358"/>
                </MultiDataTrigger.Conditions>
                <MultiDataTrigger.EnterActions>
                    <StopStoryboard BeginStoryboardName="IN"/>
                    <BeginStoryboard Name="OUT">
                        <Storyboard>
                            <DoubleAnimation Storyboard.TargetProperty="Width" To="48" Duration="0:00:0.2"/>
                        </Storyboard>
                    </BeginStoryboard>
                </MultiDataTrigger.EnterActions>
            </MultiDataTrigger>
        </Style.Triggers>
    </Style>
