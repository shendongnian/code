    <Button x:Name="BtnToClick" Height="30" Width="100" Content="Click" />
        
    <ProgressBar Height="50" Minimum="0" Maximum="100" Value="0" 
            RenderTransformOrigin="0.5,0.5" 
            Margin="0,0" Background="Transparent" 
            BorderThickness="0" Foreground="DarkCyan">
    <ProgressBar.RenderTransform>
      <TransformGroup>
        <ScaleTransform/>
        <SkewTransform/>
        <RotateTransform Angle="-90"/>
        <TranslateTransform/>
       </TransformGroup>
      </ProgressBar.RenderTransform>
      <ProgressBar.Style>
        <Style TargetType="ProgressBar">
           <Style.Triggers>
              <DataTrigger Binding="{Binding IsPressed ,ElementName=BtnToClick}" Value="True">
               <DataTrigger.EnterActions>
                  <BeginStoryboard>
                     <Storyboard>
                       <DoubleAnimation Storyboard.TargetProperty="Value" 
                                        From="0" To="100" 
                                        Duration="0:0:0:1"/>
                      </Storyboard>
                    </BeginStoryboard>
                </DataTrigger.EnterActions>
               </DataTrigger>
           </Style.Triggers>
          </Style>
        </ProgressBar.Style>
     </ProgressBar>
