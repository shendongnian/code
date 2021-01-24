    if ( .... )
    else
    {
        bool found = false;
        for (var i = 0; i < commentlist.Count; i++)
        {
            if ((commentlist[i].id) == ((int)commentid))
            {
                commentlist[i].comment = comenttext;
                found = true;
                break;
            }
        }
        if (! found)
            commentlist.Add(new CommentModel((int)commentid, (string)comenttext));
    }
