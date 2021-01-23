    using System;
    using System.Collections.Generic;
     using System.Linq;
     using System.Text;
    using System.IO;
     namespace WindowsFormsApplication1
     {
    public class User
    {
       
        public string Name { get; set; }
        public string Marks { get; set; }
       
        public static List<User> LoadUserListFromFile(string path)
        {
            var users = new List<User>();
            foreach (var line in File.ReadAllLines(path))
            {
                var columns = line.Split('\t');
                users.Add(new User
                {
                    Name = columns[0],
                    Marks = columns[1]
                   
                });
            }
            return users;
        }
    }}
