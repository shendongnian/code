    <Canvas x:Name="Canvas" xmlns:l="Your_converter_namespace" xmlns:sys="clr-namespace:System;assembly=mscorlib">
      <Canvas.Resources>
        <l:MultiplyConverter x:Key="MultiplyConverter"/>
      </Canvas.Resources>
      <Rectangle Height="100" Width="100" Fill="Blue">
        <Rectangle.Style>
          <Style TargetType="Rectangle">
            <Style.Triggers>
              <DataTrigger Binding="{Binding IsAnimationStarted}" Value="True">
                <DataTrigger.EnterActions>
                  <BeginStoryboard x:Name="Storyboard1">
                    <Storyboard TargetProperty="Tag">
                      <DoubleAnimation From="0" To="1" Duration="0:0:5"/>
                    </Storyboard>
                  </BeginStoryboard>
                </DataTrigger.EnterActions>
                <DataTrigger.ExitActions>
                  <StopStoryboard BeginStoryboardName="Storyboard1"/>
                </DataTrigger.ExitActions>
              </DataTrigger>
            </Style.Triggers>  
          </Style>
        </Rectangle.Style>
        <Rectangle.Tag>
          <sys:Double>0</sys:Double>
        </Rectangle.Tag>
        <Canvas.Left>
          <MultiBinding Converter="{StaticResource MultiplyConverter}">
            <Binding Path="ActualWidth" ElementName="Canvas"/>
            <Binding Path="Tag" RelativeSource="{RelativeSource Self}"/>
          </MultiBinding>
        </Canvas.Left>
      </Rectangle>
    </Canvas>
