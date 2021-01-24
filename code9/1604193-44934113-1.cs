    class AddAlphaEffect : ShaderEffect
    {
        // The Input property is special and will automatically receive the content of the element being rendered
        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(AddAlphaEffect), 0);
        
        public float Alpha
        {
            get { return (Point)GetValue(CenterProperty); }
            set { SetValue(CenterProperty, value); }
        }
        public static readonly DependencyProperty AlphaProperty = DependencyProperty.Register("Alpha", typeof(float), typeof(AddAlphaEffect),
            new PropertyMetadata(0.0f, PixelShaderConstantCallback(0)));
        public AddAlphaEffect()
        {
            // Reference the compiled shader here, which should be included as a resource in your applciation.
            // ResourceHelper is my own utility that formats URIs for me. The returned URI
            // string will be something like /AssemblyName;component/Effects/AddAlpha.ps
            PixelShader = new PixelShader() { UriSource = ResourceHelper.GetResourceUri("Effects/AddAlpha.ps", relative: true)};
            UpdateShaderValue(AlphaProperty);
        }
    }
