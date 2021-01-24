    public TagsViewModel(ITagService tagService)
    {
        AddBelgium = ReactiveCommand.Create(() =>
            tagService.AddOrUpdate(new TagDto {Id = 5, Name = @"Country\Belgium"}));
        TagsSubscription = tagService.TagLeafs
            .Connect()
            .TransformToTree(leaf => leaf.ParentId)
            .Transform(node => new TagLeafViewModel(node))
            .Sort(SortExpressionComparer<TagLeafViewModel>.Ascending(vm => vm.Name))
            .Bind(out _tagTree)
            .Subscribe();
    }
