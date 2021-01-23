    public LinkGen<T> Copy(LinkListGen<T> list2)
    {
        /* You may want to do edge case checking here (check for null on list2, etc) */
        /* create a new starting link, copied from the starting link on List.Data.*/
        LinkGen<T> copy = new LinkGen<T>(list2.list.Data, null);
        /* declare a temp pointer on the copy */
        LinkGen<T> cpTp = copy;
        /* declare a temp pointer on the original list */
        LinkGen<T> temp = list2.list;
        while (temp.Next != null)
        {
            /* Create a new Link, copied from temp.Next and point cpTp.Next to it. */
            cpTp.Next = new LinkGen<T>(temp.Next, null);
            /* Increment both pointers */
            temp = temp.Next;
            cpTp = cptp.Next;
        }
        /* Returning the first node of the copied Linked List */
        return copy;
    }
