                    var model = _mapper.Map<ThingModel>(
                    //realthing,
                    opt =>
                    {
                        opt.Items.Clear();
                        mappingOptions.Aggregate(
                            opt.Items,
                            (items, option) =>
                            {
                                items.Add(option.Key, option.Value);
                                return items;
                            }
                            );
                    }
                    );
