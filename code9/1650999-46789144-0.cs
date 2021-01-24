        internal class CustomTransientErrorDetectionStrategy
            : ITransientErrorDetectionStrategy
        {
            public bool IsTransient(Exception ex) =>
                ex.IsTransientSpannerFault();
        }
