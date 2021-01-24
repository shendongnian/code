    public class RemoveEmptyRunsBehavior : Behavior<RichTextBlock>
    {
        protected override void OnAttached()
        {
            RemoveWhitespaceRuns(this.AssociatedObject);
        }
    
        private void RemoveWhitespaceRuns(RichTextBlock tb)
        {
            var pairs = from p in tb.Blocks.OfType<Paragraph>()
                from r in p.Inlines.OfType<Run>()
                where r.Text == " "
                select new { p, r };
    
            foreach (var space in pairs)
            {
                space.p.Inlines.Remove(space.r);
            }
        }
    }
