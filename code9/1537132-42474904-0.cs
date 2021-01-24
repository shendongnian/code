    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Comment comment = new Comment();
                comment.Initialize();
                comment.SortComments();
                comment.PrintSortedComments();
            }
        }
        public class Comment
        {
            public static List<Comment> comments = new List<Comment>();
            public List<Comment> sortedComments = null;
            public int Id { get; set; }
            public int Depth { get; set; }
            public string Body { get; set; }
            public int? ReplyId { get; set; }
            public void Initialize()
            {
                comments.Add(AddNewComment(1, null, ""));
                comments.Add(AddNewComment(2, null, ""));
                comments.Add(AddNewComment(3, null, ""));
                comments.Add(AddNewComment(4, 1, ""));
                comments.Add(AddNewComment(5, 4, ""));
                comments.Add(AddNewComment(6, 1, ""));
                comments.Add(AddNewComment(7, null, ""));
                comments.Add(AddNewComment(8, 7, ""));
                comments.Add(AddNewComment(9, 8, ""));
                comments.Add(AddNewComment(10, 9, ""));
                comments.Add(AddNewComment(11, 2, ""));
                comments.Add(AddNewComment(12, 11, ""));
                comments.Add(AddNewComment(13, 1, ""));
                comments.Add(AddNewComment(14, 13, ""));
            }
            
            public Comment AddNewComment(int id, int? replyId, string body)
            {
                return new Comment
                {
                    Id = id,
                    ReplyId = replyId,
                    Body = body
                };
            }
            public void SortComments()
            {
                sortedComments = new List<Comment>();
                List<Comment> levelZeroComments = comments.Where(x => x.ReplyId == null).OrderBy(x => x.Id).ToList();
                foreach (Comment comment in levelZeroComments)
                {
                    sortedComments.Add(comment);
                    comment.Depth = 0;
                    RecusiveSort(comment.Id, 1);
                }
            }
            public void RecusiveSort(int id, int depth)
            {
                List<Comment> childComments = comments.Where(x => x.ReplyId == id).OrderBy(x => x.Id).ToList();
                foreach (Comment comment in childComments)
                {
                    sortedComments.Add(comment);
                    comment.Depth = depth;
                    RecusiveSort(comment.Id, depth + 1);
                }
            }
            public void PrintSortedComments()
            {
                Console.WriteLine("/*");
                foreach (Comment sortComment in sortedComments)
                {
                    Console.WriteLine(" * {0}{1}", new string('-', sortComment.Depth), sortComment.Id);
                }
                Console.WriteLine("* */");
                Console.ReadLine();
            }
        }
    }
