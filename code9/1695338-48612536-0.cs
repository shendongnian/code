    <Rectangle x:Name="ImageRect" ...>
        <Rectangle.Fill>
            <ImageBrush ImageSource="/Images/close.ico"/>
        </Rectangle.Fill>
    </Rectangle>
    <Rectangle ...>
        <Rectangle.Style>
            <Style TargetType="Rectangle">
                <Setter Property="Fill" Value="#f9b129"/>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsMouseOver, ElementName=ImageRect}"
                                 Value="True">
                        <Setter Property="Fill" Value="#fbc86A"/>
                    </DataTrigger>
                </Style.Triggers>                    
            </Style>
        </Rectangle.Style>
    </Rectangle>
