    ...
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<RemoteData, List<PriceDto>>()
                        .ConvertUsing(source => source.Prices?.Select(p => new PriceDto
                            {
                                Ticker = source.Security?.Ticker,
                                Open = p.Open,
                                Close = p.Close
                            }).ToList()
                        );
                });
    ...
