    var query = (from royalHIstory in ctx.tblRoyalHistories
    join historyComment in ctx.tblRoyalHistoryComments
    on royalHIstory.RoyalHistoryID equals historyComment.RoyalHistoryID
    orderby royalHIstory.IndexNum ascending
    where royalHIstory.InstNmbr == instnmbr
    select new {royalHIstory,historyComment }).AsEnumerable().Select(row=>new
    {
        RoyalHistoryID = row.royalHIstory.RoyalHistoryID,
        RoyalHistoryCommentID = row.historyComment.RoyalHistoryCommentID,
        InstNmbr = row.royalHIstory.InstNmbr,
        IndexNum = row.royalHIstory.IndexNum,
        RoyalIns = row.royalHIstory.RoyalIns,
        RoyalComment = row.historyComment.Comment,
        Name = (from memberName in ctx.tblMembers
               join instruct in ctx.tblInstructors
               on memberName.MemberID equals instruct.MemberID
               where Convert.ToInt32(instruct.InstructorInstrNo) == row.royalHIstory.RoyalIns
               select memberName.MemberFirstName + " " + memberName.MemberLastName).FirstOrDefault()
    });
