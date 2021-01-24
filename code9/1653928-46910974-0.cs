    public static class LineExtensions
    {
        public static bool Matches(this Line line, LinePresentation presentation)
        {
            return line.LineReferenceId == presentation.LineReferenceId
                   && line.Name == presentation.Name;
        }
    }
