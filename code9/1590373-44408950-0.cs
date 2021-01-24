    using System;
    using System.IO;
    using System.Xml.Serialization;
    
    public class Users
    {
        public class User
        {
            public int UserId { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
            public string ProfileImage { get; set; }
            public string Name { get; set; }
            public int FeedId { get; set; }
            public string Description { get; set; }
            public string Interest { get; set; }
            public int InterestId { get; set; }
        }
    
        [XmlElement("User")]
        public User[] ListUsers { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            var ser = new XmlSerializer(typeof(Users));
            using (var sr = new StringReader(xml))
            {
                var obj = (Users)ser.Deserialize(sr);
                Console.WriteLine(obj.ListUsers.Length); // 2
            }
        }
    
    
    
        const string xml = @"<Users>
          <User>
                <UserId>1</UserId>
                <Email>abc@gmail.com</Email>
                <UserName>abc</UserName>
                <ProfileImage>20160816105401206.jpeg</ProfileImage>
                <Name>abc</Name>
    
                <InterestId>8</InterestId>
                <FeedId>4608</FeedId>
                <Description>Test</Description>
                <Interest>Cricekt</Interest>    
    
                <InterestId>12</InterestId>
                <FeedId>4609</FeedId>
                <Description>Test 2</Description>
                <Interest>Read</Interest>    
          </User>
           <User>
                <UserId>2</UserId>
                <Email>xyz@gmail.com</Email>
                <UserName>xyz</UserName>
                <ProfileImage>20160816105401207.jpeg</ProfileImage>
                <Name>xyz</Name>
    
                <InterestId>8</InterestId>
                <FeedId>4610</FeedId>
                <Description>Test 3</Description>
                <Interest>swim</Interest>    
    
                <InterestId>12</InterestId>
                <FeedId>4610</FeedId>
                <Description>Test 3</Description>
                <Interest>drive</Interest>    
          </User>
     </Users>";
    }
