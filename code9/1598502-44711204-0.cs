        public void checkComment(Comment comment)
        {
            //Check if the comment is valid
            if (comment != null)
            {
                //Do whatever you want to do with your comment for example print to console
                Console.WriteLine(String.Format("Comment: {0}", comment.Text));
                //Check if i have any sub comments
                if (comment.SubComments.Count > 0)
                {
                    //Process each sub comment (recursive)
                    comment.SubComments.ForEach(x => checkComment(x));
                }
            }
        }
