        private XGraphicsPdfRendererOptions _renderOptions { get; set; }
        public XGraphicsPdfRendererOptions RenderOptions
        {
            get
            {
                if (_renderOptions == null)
                {
                    _renderOptions = new XGraphicsPdfRendererOptions();
                }
                return _renderOptions;
            }
            set
            {
                _renderOptions = value;
            }
        }
