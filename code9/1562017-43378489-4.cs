    public class BaseRecord<TUserInfo> : IBaseRecord<TUserInfo>
    	where TUserInfo : BaseUserInfo
    {
    	public virtual DateTime CreationTime { get; set; }
    	public virtual TUserInfo UserInfo { get; set; }
    }
