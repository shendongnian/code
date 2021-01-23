    public class Likes : IComparable<T>
    {
        //previous implementation...
        public int CompareTo(object obj)
        {
            if(obj is Comments)
                return this.Liketime.CompareTo((obj as Comments).Commenttime);
            if(obj is Likes)
                return this.Liketime.CompareTo((obj as Likes).Liketime);
            throw new NotSupportedException();
        }
    }
    public class Comments: IComparable<T>
    {
        //previous implementation...
        public int CompareTo(object obj)
        {
            if(obj is Comments)
                return this.Commenttime.CompareTo((obj as Comments).Commenttime);
            if(obj is Likes)
                return this.Commenttime.CompareTo((obj as Likes).Liketime);
            throw new NotSupportedException();
        }
    }
    // And now You just need to use them to sort:
    List<Comments> lComments = someList.OrderBy(a => a.Commenttime);
    List<Likes> lLikes = someList2.OrderBy(a => a.Liketime);
    List<object> lResults = new List<object>(lComments);
    lResults.AddRange(lLikes);
    lResults.Sort();
