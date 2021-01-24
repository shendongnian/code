    var itemInList = commentlist.Where(li => li.id == (int)commentid).FirstOrDefault();
    if (String.IsNullOrEmpty(comenttext)) //incase user clears the textbox
    {
      if (itemInList != null)
        commentlist.Remove(itemInList);
    }
    else //add new or update incase its a comment change
    {
      if (itemInList != null)
        itemInList.comment = comenttext;
      else
        commentlist.Add(new CommentModel((int)commentid, comenttext));
    }
