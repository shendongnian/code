      public void Copy(LinkListGen<T> list2)
        {
          
            LinkGen<T> temp = list2.list;
            while (temp != null)
            {
                AppendItem(temp.Data);
                temp = temp.Next;
            }
        }
