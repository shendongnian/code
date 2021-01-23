    public class XGraphicsPdfRendererOptions
    {
        public XGraphicsPdfRenderMode RenderMode { get; set; }
        public bool IncludeRenderModeForPage { get; set; }
        public bool IncludeRenderModeForObject { get; set; }
    }
    public enum XGraphicsPdfRenderMode
    {
        Text_Render_Mode_Fill = 0,
        Text_Render_Mode_Stroke = 1,
        Text_Render_Mode_Fill_Stroke = 2,
        Text_Render_Mode_Invisible = 3
    }
