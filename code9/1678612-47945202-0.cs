    namespace Evaluation.Entitys
    {
        public interface IUserEntity
        {
            string UserAccountId { get; set; }
        }
    
        public class UserEntity : IUserEntity
        {
            public string UserAccountId { get; set; }
    
            public UserEntity()
            {
    
            }
        }
    
        public class UserEntityTransport : IUserEntity
        {
            public string UserAccountId { get; set; }
    
            public UserEntityTransport(IUserEntity e)
            {
                UserAccountId = e.UserAccountId;
            }
        }
    }
    #if __MOBILE__
    
    namespace Evaluation.Moible 
    {
    
    
        using SQLite;
        using SQLite.Net;
        public class UserEntityMobileDB : IUserEntity
        {
            [Index]
            public string UserAccountId { get; set; }
            public UserEntityMobileDB(IUserEntity e)
            {
                UserAccountId = e.UserAccountId;
            }
        }
    }
    #endif
    
    #if __WIN32__
    namespace Evaluation.Server
    {
        using Evaluation.Entitys;
        using ServiceStack.DataAnnotations;
        using SQLite;
    
        public class UserEntityServerDB : IUserEntity
        {
            [Indexed]
            public string UserAccountId { get; set; }
    
            public UserEntityServerDB(IUserEntity e)
            {
                UserAccountId = e.UserAccountId;
    
            }
        }
    }
    #endif 
