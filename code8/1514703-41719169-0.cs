    namespace MyProject.Models
    {
        public partial class Profile
        {
            public string ProfileImageURL
            {
                get
                {
                    return "~/images/folder/folder/" + this.ImageFileName;
                }
            }
        }
    }
