      <Trigger Property="IsEnabled" Value="False">
          <Trigger.EnterActions>
              <BeginStoryboard>
                  <Storyboard>
                      <DoubleAnimation Storyboard.TargetProperty="Opacity" To="0" Duration="0:0:0.2"/>
                  </Storyboard>
              </BeginStoryboard>
          </Trigger.EnterActions>
          <Trigger.ExitActions>
              <BeginStoryboard>
                  <Storyboard>
                      <DoubleAnimation Storyboard.TargetProperty="Opacity" To="1" Duration="0:0:0.2"/>
                  </Storyboard>
              </BeginStoryboard>
          </Trigger.ExitActions>
      </Trigger>
