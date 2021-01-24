    public class RemoveEmptyRunsBehavior : Behavior<RichTextBlock>
    {
        protected override void OnAttached()
        {
            RemoveWhitespaceRuns(this.AssociatedObject);
        }
        private void RemoveWhitespaceRuns(RichTextBlock tb)
        {
            var tuples = from p in tb.Blocks.OfType<Paragraph>()
                from r in p.Inlines.OfType<Run>()
                where r.Text == " "
                select new { Paragraph = p, Run = r };
            foreach (var tuple in tuples)
            {
                tuple.Paragraph.Inlines.Remove(tuple.Run);
            }
        }
    }
