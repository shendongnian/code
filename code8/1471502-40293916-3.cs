    public partial class ChildMap : ClassMap<Child> {
            public ChildMap(){
                Table("[child]");
                LazyLoad();
                Id(x => x.ChildId ).GeneratedBy.Identity().Column("ChildId ");
                Map(x => x.Name).Column("Name");
                References(x => x.Parent).Column("ParentId").Not.Nullable();
            }
        }
    
    public partial class ParentMap : ClassMap<Parent> {
            public ParentMap(){
                Table("[parent]");
                LazyLoad();
                Id(x => x.ParentId).GeneratedBy.Identity().Column("ParentId");
                Map(x => x.Name).Column("Name");
            }
        }
