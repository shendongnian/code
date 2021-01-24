    class InvertEffect : ShaderEffect
    {
        private static readonly PixelShader _shader =
            new PixelShader { UriSource = new Uri("pack://application:,,,/<my shader file>.ps") };
        public InvertEffect()
        {
            PixelShader = _shader;
            UpdateShaderValue(InputProperty);
        }
        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }
        public static readonly DependencyProperty InputProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(InvertEffect), 0);
    }
