    if (entity.Metadata.FindProperty(prop.Name) == null)
        continue;
    var p = entity.Property(prop.Name);
    if (p.IsModified)
        props.Add(new { f = prop.Name, o = p.OriginalValue, c = p.CurrentValue });
