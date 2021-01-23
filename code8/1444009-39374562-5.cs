        <!-- Invoke VisualStateManager to handle it instead of Trigger as requested. -->
        <VisualStateManager.VisualStateGroups>
           <VisualStateGroup x:Name="CommonStates">
              <VisualStateGroup.Transitions>
                 <VisualTransition To="MouseOver" GeneratedDuration="0:0:0.2"/>
                 <VisualTransition From="MouseOver" GeneratedDuration="0:0:0.2"/>
              </VisualStateGroup.Transitions>
              <VisualState x:Name="Normal"/>
              <VisualState x:Name="MouseOver">
                 <Storyboard>
                    <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" 
                                                   Storyboard.TargetName="buttonLight"
                                                   Duration="0:0:1">
                       <EasingDoubleKeyFrame KeyTime="0" Value="1"/>
                    </DoubleAnimationUsingKeyFrames>
                 </Storyboard>
              </VisualState>
              <VisualState x:Name="Pressed"/>
              <VisualState x:Name="Disabled"/>
           </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>
