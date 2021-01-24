    public interface IGroupService {
        void UpdateGroup(Group group);
        int NewGroup(Group group);
    }
    public class GroupService : IGroupService {
        public int NewGroup(Group group) {
            RioBravoManagerContext ctx = new RioBravoManagerContext();
            ctx.Groups.Add(group);
            ctx.SaveChanges();
            return group.ID;
        }
        public void UpdateGroup(Group group) {
            RioBravoManagerContext ctx = new RioBravoManagerContext();
            if (ctx.Groups.Where(g => g.ID == group.ID).Any()) {
                Group cgroup = ctx.Groups.Where(g => g.ID == group.ID).SingleOrDefault();
                cgroup.Name = group.Name;
                cgroup.IsOperations = group.IsOperations;
                cgroup.OperationPermission = group.OperationPermission;
            } else {
                ctx.Groups.Add(group);
            }
            ctx.SaveChanges();
        }
    }
