        public MappingProfiles()
        {
            CreateMap<Post, ManagePostViewModel>().ForMember(d => d.ActiveInDays, conf => conf.ResolveUsing(CalculateActiveDays));
        }
        private static object CalculateActiveDays(Post arg)
        {
            return (DateTime.UtcNow - arg.CreatedAt).TotalDays;
        }
 
