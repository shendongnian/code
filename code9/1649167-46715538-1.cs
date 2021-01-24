    public override async Task Initialize()
    {
        await base.Initialize();
        Slides = _mapper.Map<ICollection<SlideListItemViewModel>>(await _serverClient.GetSlideList());
        foreach(var slide in Slides)
        {
            slide.ServerClient = _serverClient;
        }
    }
