    using System;
    using System.Linq.Expressions;
    namespace Program
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                Expression<Func<CommentUrlCommon, bool>> predicate = f => f.Id == 1;
                //As you know this doesn't work
                //Expression converted = Expression.Convert(predicate, typeof(Expression<Func<CommentUrl, bool>>));
                //this doesn't work either...
                Expression converted2 = Expression.Convert(predicate, typeof(Expression<Func<CommentUrlCommon, bool>>));
                Console.ReadLine();
            }
        }
        public class CommentUrlCommon
        {
            public int Id { get; set; }
        }
        public class CommentUrl
        {
            public int Id { get; set; }
        }
    }
