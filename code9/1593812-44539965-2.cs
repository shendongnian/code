    public class UserService : IUserService
    {
          private readonly IUserRepository _user;
            
          public UserService(IUserRepository  user)
          {
             _user=user;
          }
                
          public List<TopContributorViewModel> GetResult()
          {
             var result = _user.FindAll(u => u.Active)
                               .Include(p=>p.Posts)
                               .Include(p=>p.Comments)
                               .Select(model=>new TopContributorViewModel
                                {
                                  UserName = model.Name,
                                  UserId = model.Id,
                                  PostCount = model.Posts.Count(u=>u.IsPublished==true && u.UserId==model.Id),
                                  CommentCount = model.Comments.Count(u => u.IsPublished == true && u.UserId == model.Id)
                                });
                return result.ToList();
          }
        
    }
