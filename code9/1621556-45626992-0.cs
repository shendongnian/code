    <Style TargetType="{x:Type local:NotePad}">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate  TargetType="local:NotePad">
                        <Canvas>
                            <Canvas.Background>
                                <DrawingBrush Stretch="None" TileMode="Tile"  ViewportUnits="Absolute">
                                    <DrawingBrush.Viewport>
                                        <MultiBinding>
                                            <MultiBinding.Converter>
                                                <conv:RectConverter/>
                                            </MultiBinding.Converter>
                                            <Binding Path="{TemplateBinding ViewPortWidth}"/>
                                            <Binding Path="{TemplateBinding ViewPortHeight}"/>
                                        </MultiBinding>
                                    </DrawingBrush.Viewport>
........................................................
     public class NotePad : Control
        {
            static NotePad()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(NotePad), new FrameworkPropertyMetadata(typeof(NotePad)));
            }
    
            #region [ViewPortWidth]
            public double ViewPortWidth
            {
                get { return (double)GetValue(ViewPortWidthProperty); }
                set { SetValue(ViewPortWidthProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for ViewPortWidth.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty ViewPortWidthProperty =
                DependencyProperty.Register("ViewPortWidth", typeof(double), typeof(NotePad), new PropertyMetadata(0.0));
    
            #endregion
