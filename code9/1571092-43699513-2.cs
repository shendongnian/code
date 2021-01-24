    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    namespace InsuranceWebAPI.Models
    {
    public class RootObject
    {
        public IEnumerable<User> clients { get; set; }
    }
    public class User
    {
        private string email;
        private string id;
        private string name;
        private string role;
        public User()
        {
        }
        public User(string email, string id, string name, string role)
        {
            this.Email = email;
            this.Id = id;
            this.Name = name;
            this.Role = role;
        }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }
    }
    }
