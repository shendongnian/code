    [LayoutRenderer("intercept")]
    public sealed class InterceptLayoutRendererWrapper : WrapperLayoutRendererBuilderBase
    {
        /// <summary>
        /// Option you could set from config or code
        /// </summary>
        [DefaultValue(true)]
        public bool Option1 { get; set; }
        /// <summary>
        /// Renders the inner layout contents.
        /// OR override TransformFormattedMesssage, and change the stringbuilder (less string allocations)
        /// </summary>
        /// <param name="logEvent">The log event.</param>
        /// <returns>Contents of inner layout.</returns>
        protected override string RenderInner(LogEventInfo logEvent)
        {
            var text = this.Inner.Render(logEvent);
            return interceptSomething(text);
        }
    }
