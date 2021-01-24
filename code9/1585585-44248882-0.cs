    public class TagService : ITagService
    {
        private readonly SourceCache<TagDto, int> _tagDtos = new SourceCache<TagDto, int>(t => t.Id);
        public IObservableCache<TagDto, int> TagDtos => _tagDtos;
        private readonly SourceCache<TagLeaf, string> _tagLeafs = new SourceCache<TagLeaf, string>(t => t.Id);
        public IObservableCache<TagLeaf, string> TagLeafs => _tagLeafs;
        public TagService()
        {
            _tagDtos.AddOrUpdate(new[]
            {
                new TagDto {Id = 1, Name = @"Country\Canada\Alberta"},
                new TagDto {Id = 2, Name = @"Country\Canada\British Columbia"},
                new TagDto {Id = 3, Name = @"Country\USA\California"},
                new TagDto {Id = 4, Name = @"Country\USA\Texas"}
            });
            _tagDtos
                .Connect()
                .Transform(dto =>
                {
                    var names = dto.Name.Split(new[] {'\\'}, StringSplitOptions.RemoveEmptyEntries);
                    var results = new TagLeaf[names.Length];
                    var parentId = "";
                    for (var i = 0; i < names.Length; i++)
                    {
                        var name = names[i];
                        var id = $"{parentId}{name}\\";
                        results[i] = new TagLeaf(id, parentId, dto.Id, name);
                        parentId = id;
                    }
                    return new TagBranch(dto.Id, results);
                })
                .ForEachChange(change =>
                {
                    var branch = change.Current;
                    switch (change.Reason)
                    {
                        case ChangeReason.Remove:
                            var lastLeaf = branch.Leaves.Last();
                            _tagLeafs.RemoveKey(lastLeaf.Id);
                            break;
                        case ChangeReason.Add:
                            foreach (var leaf in branch.Leaves)
                            {
                                if (_tagLeafs.Keys.Contains(leaf.Id))
                                    continue;
                                _tagLeafs.AddOrUpdate(leaf);
                            }
                            break;
                    }
                })
                .Subscribe();
        }
        public void AddOrUpdate(TagDto dto)
        {
            _tagDtos.AddOrUpdate(dto);
        }
    }
