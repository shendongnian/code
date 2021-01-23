    public Boolean Contains(T item, ref Node<T> tree)
    {
           if (tree == null)
           {
                return false;
           }
           if (tree.data == item)
           {
               return true;
           }  
    
    
           if (item.CompareTo(tree.Data) < 0)
           {
                return Contains(ref tree.Left);
           }
           if (item.CompareTo(tree.Data) > 0)
           {
                return Contains(ref tree.Right);
           }
           return false;
      }
