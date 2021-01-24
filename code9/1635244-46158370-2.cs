    // from
    public interface ICommentDAL<T> where T : BaseEntity<int>, IBaseDAL<T, int>
    // to
    public interface ICommentDAL<T> : IBaseDAL<T, int>
        where T : BaseEntity<int>
    // or to
    public interface ICommentDAL : IBaseDAL<PageComment, int>
