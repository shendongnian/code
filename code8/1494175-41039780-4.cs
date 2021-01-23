       public class MyRoleProvider:RoleProvider
       { UserDb ObjDb;
      public override string[] GetRolesForUser(string username)
        {
            string[] s = { ObjDb.GetAll().Where(x => x.Username ==username.ToUpper()).FirstOrDefault().Privleges };
            return s;
        }
      }
