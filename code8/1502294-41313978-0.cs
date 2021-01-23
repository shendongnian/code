    public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
          var result = new List<ClassificationSpan>();
          foreach (var line in span.Snapshot.Lines.Where(x => x.GetText().Contains("=>")))
          {
    
            foreach (var idx in line.GetText().AllIndexesOf("=>"))
            {
             result.Add(new ClassificationSpan(new SnapshotSpan(line.Snapshot, new Span(line.Start.Position + idx, 2)), this.classificationType));
            }
          };
    
          return result;
        }
