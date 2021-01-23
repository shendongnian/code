    public void Copy(LinkListGen<T> list2)
    {
        LinkGen<T> temp = list2.list; /* This doesn't create a new linked list, it simply points the temp variable to the existing Linked list. */
        while (temp != null)  /* This will essentially start traversing the existing list. At the end, both lists will have the same starting node. */
        {
            Concat(list2);
            AppendItem(list2.list.Data);
            temp = temp.Next;
        }
    }
