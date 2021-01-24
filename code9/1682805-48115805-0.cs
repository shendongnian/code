    <Image RenderOptions.BitmapScalingMode="HighQuality" Source="/Axon.Oscillographic.Viewer;component/Icons/save.png"/>
     <Image.Style>
      <Style TargetType="Image">
       <Style.Triggers>
            <DataTrigger Binding="{Binding IsEnabled, 
                                           RelativeSource={RelativeSource AncestorType=Button}}" 
                         Value="False">
                <Setter Property="Opacity" Value="0.75"/>
            </DataTrigger>
       </Style.Triggers>
      </Style>
     </Image.Style>
    </Image>
