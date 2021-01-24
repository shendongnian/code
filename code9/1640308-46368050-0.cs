        cfg.CreateMap<Dictionary<Action, bool>, WebAction>()
                .ForMember(dest => dest.IsFbClicked,
                                    opt => opt.MapFrom(s => s.ContainsKey(Action.IsFbClicked)?s[Action.IsFbClicked]:fals‌​e))
                .ForMember(dest => dest.IsTwitterClicked,
                             opt => opt.MapFrom(s => s.ContainsKey(Action.IsTwitterClicked)?s[Action.IsTwitterClicked]:fals‌​e))
    
               });
