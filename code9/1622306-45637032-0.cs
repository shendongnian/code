    .ForMember(d => d.AssetModelList,
               op => op.MapFrom(s => string.Join("; ",
                                                 s.Assets
                                                  // Remove null or whitespace
                                                  // Alternatively, a.ModelName != null
                                                  .Where(a => !string.IsNullOrWhiteSpace(a.ModelName))
                                                  .Select(a => a.ModelName)
                                                  .ToArray<string>())))
