    List<Comments> lComments = someList.OrderBy(a => a.Commenttime);
    List<Likes> lLikes = someList2.OrderBy(a => a.Liketime);
    List<object> lResults = new List<object>();
    int iComment = 0, iLike = 0;
    for(int i = 0; i < lComments.Count() + lLikes.Count(); i++)
    {
        if(lComments.Count() >= iComment) //set Like
        {
            lResults.Add(lLikes[iLike++]);
            continue;
        }
        
        if(lLikes.Count() >= iLike ) //set Comment
        {
            lResults.Add(lComments[iComment++]);
            continue;
        }
        if(lLikes[iLike].Liketime > lComments[iComment].Commenttime)
            lResults.Add(lComments[iComment++]);
        else
            lResults.Add(lLikes[iLike++]);
    }
