     <Button Content="Click">
       <Button.Triggers>
           <EventTrigger RoutedEvent="Button.Click">
               <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation Storyboard.TargetProperty="Value" 
                                            From="0" To="{Binding Bar1}" 
                                            Duration="{Binding Duration1}"/>
                         </Storyboard>
                    </BeginStoryboard>
           </EventTrigger>
       </Button.Triggers>
    </Button>
