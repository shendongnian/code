        int _realizedRenderingMode;  // Reference: TABLE 5.2  Text state operators / Page 398
        public void RealizeFont(XFont font, XBrush brush, int renderingMode)
        {
            const string format = Config.SignificantFigures3;
            // So far rendering mode 0 (fill text) and 2 (fill, then stroke text) only.
            RealizeBrush(brush, _renderer._colorMode, renderingMode, font.Size); // _renderer.page.document.Options.ColorMode);
            // Realize rendering mode.
            if (_realizedRenderingMode != renderingMode)
            {
                _renderer.AppendFormatInt("{0} Tr\n", renderingMode);
                _realizedRenderingMode = renderingMode;
            }
