    private LinkGen<T> LastNode (LinkGen<T> node)
    {
        var temp = node;
        while (temp != null && temp.Next != null)
            temp = temp.Next;
        return temp;
    } 
    public void Copy(LinkListGen<T> list2)
    {
        LinkGen<T> cpTp = LastNode(this);
        LinkGen<T> temp = list2.list;
        while (temp.Next != null && list2 != null)
        {
            /* Create a new Link, copied from temp.Next and point cpTp.Next to it. */
            cpTp.Next = new LinkGen<T>(temp.Next, null);
            /* Increment both pointers */
            temp = temp.Next;
            cpTp = cptp.Next;
        }
    }
