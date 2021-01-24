    services.AddScoped(factory =>
                {
                    IHusbandryTaskMapper GetHusbandryTaskMapper(HusbandryTaskSubType subType)
                    {
                        switch (subType)
                        {
                            case HusbandryTaskSubType.AnimalCull:
                                return new HusbandryCullAnimalTaskMapper(factory.GetService<IUserIdentityResolver>(), factory.GetService<ILanguageProvider>());
                            case HusbandryTaskSubType.CageChange:
                            case HusbandryTaskSubType.CensusCheck:
                                return new CageTaskMapper(factory.GetService<IUserIdentityResolver>(), factory.GetService<ILanguageProvider>());
                            default:
                                throw new NotImplementedException();
                        }
                    }
    
                    return (Func<HusbandryTaskSubType, IHusbandryTaskMapper>)GetHusbandryTaskMapper;
                });
