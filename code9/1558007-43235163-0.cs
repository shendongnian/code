    public IEnumerable<Paper> GetPapersForReview(int userID, string courseID, string role)
    {
        using (USGEntities context = new USGEntities())
        {
            var result = context.Papers
                .Include(paper => paper.User)
                .Where(paper => paper.Status == "REV" && paper.Deleted == false && paper.User_ID == userID && paper.User.Role.Name == role && paper.Course_ID == courseID)
                .ToList();
            return result;
        }
    }
