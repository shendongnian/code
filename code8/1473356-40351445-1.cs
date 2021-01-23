    public LinkGen<T> Copy(LinkListGen<T> list2)
    {
        /* You may want to do edge case checking here (check for null on list2, etc) */
        LinkGen<T> copy = new LinkGen<T>(list2.list.Data, null);
        /* declare a temp pointer on the copy */
        LinkGen<T> cpTp = copy;
        /* declare a temp pointer on the original list */
        LinkGen<T> temp = list2.list;
        while (temp.Next != null)
        {
            cpTp.Next = new LinkGen<T>(temp.Next, null);
            /* Increment both pointers */
            temp = temp.Next;
            cpTp = cptp.Next;
        }
        /* Returning the first node of the copied Linked List */
        return copy;
    }
