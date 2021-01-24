     public class BindableSKCanvasView : SKCanvasView
        {
        
            public static readonly BindableProperty ColorProperty =
                    BindableProperty.Create("Color", typeof(SKColor), typeof(BindableSKCanvasView),defaultValue:SKColors.Black, defaultBindingMode: BindingMode.TwoWay, propertyChanged: RedrawCanvas);
        
            public SKColor Color
            {
                get => (SKColor)GetValue(ColorProperty);
                set => SetValue(ColorProperty, value);
            }
        
        
            private static void RedrawCanvas(BindableObject bindable, object oldvalue, object newvalue)
            {
                BindableSKCanvasView bindableCanvas = bindable as BindableSKCanvasView;
            bindableCanvas.InvalidateSurface();
            }
        }
