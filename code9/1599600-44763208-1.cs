    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace DemoWebForm
    {
        public partial class RepeaterDemo : System.Web.UI.Page
        {
            public class Comment
            {
                public int Id { get; set; }
                public string Name { get; set; }
            }
    
            public static IList<Comment> Comments = new List<Comment>
            {
                new Comment {Id = 1, Name = "One"},
                new Comment {Id = 2, Name = "Two"},
                new Comment {Id = 3, Name = "Three"}
            };
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    Repeater1.DataSource = Comments;
                    Repeater1.DataBind();
                }
            }
    
            protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
            {
                if (e.CommandName == "Delete")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    var comment = Comments.FirstOrDefault(c => c.Id == id);
                    Comments.Remove(comment);
    
                    Repeater1.DataSource = Comments;
                    Repeater1.DataBind();
                }
            }
        }
    }
