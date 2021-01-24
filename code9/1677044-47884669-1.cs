    <Style TargetType="Button" x:Key="SunkenEffectStyle">
     <Style.Triggers>
       <EventTrigger RoutedEvent="Button.Click">
         <EventTrigger.Actions>
           <BeginStoryboard>
             <Storyboard>
                <ThicknessAnimationUsingKeyFrames Storyboard.TargetProperty="BorderThickness" BeginTime="00:00:00">
                   <SplineThicknessKeyFrame KeyTime="00:00:01" Value="10,10,0,0" />
                   <SplineThicknessKeyFrame KeyTime="00:00:03" Value="0,0,0,0" />
                </ThicknessAnimationUsingKeyFrames>
             </Storyboard>
           </BeginStoryboard>
       </EventTrigger.Actions>
      </EventTrigger>
     </Style.Triggers>
    </Style>
