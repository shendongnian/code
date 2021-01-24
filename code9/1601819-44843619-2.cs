    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    namespace ConsoleApplication63
    {
        class Program
        {
            static void Main(string[] args)
            {
                Context _context = new Context() {
                    UserRoles = new List<UserRole>() {
                        new UserRole() { RoleId = "1", UserId = "1"},
                        new UserRole() { RoleId = "2", UserId = "3"},
                        new UserRole() { RoleId = "3", UserId = "2"},
                        new UserRole() { RoleId = "4", UserId = "4"}
                        },
                    Users = new List<User>() {
                        new User() { 
                            Id = "3", UserName = "ABC", Roles = new List<Role> {
                                new Role() { Id = "100", Name = "ABC"},
                                new Role() { Id = "101", Name = "DEF"},
                                new Role() { Id = "102", Name = "GHI"},
                                new Role() { Id = "103", Name = "JKL"},
                                new Role() { Id = "104", Name = "MNO"}
                            }
                        }
                    },
                    Roles = new List<Role>() {
                        new Role() { Name = "XYZ", Id = "2"}
                    }
                };
                        
                string id = "3";
                List<UserRole> results = (from users in _context.UserRoles
                    where users.UserId == id
                    join  user in  _context.Users  on users.UserId equals user.Id
                    join role in _context.Roles on users.RoleId  equals role.Id
                    select   new  { Roles = user.Roles, UserId = user.Id})
                    .Select(x => x.Roles.Select(y => new UserRole() { RoleId = y.Id, UserId = x.UserId}).ToList()).FirstOrDefault();
            }
     
        }
        public class Context
        {
            public List<User> Users { get; set; }
            public List<Role> Roles{ get; set; }
            public List<UserRole> UserRoles{ get; set; }
        }
        public class UserRole
        {
            public string UserId { get; set; }
            public string RoleId { get; set; }
        }
        public class User {
           public string Id { get; set; }
           public string UserName { get; set; }
           public List<Role> Roles { get; set; }
        }
        public class Role {
           public string Id {get; set; }
           public string Name { get; set; }
        }
    }
