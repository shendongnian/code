            var item1 = new LinkedListNode<string>("one");
            var item2 = new LinkedListNode<string>("two");
            var item3 = new LinkedListNode<string>("three");
            var list = new LinkedList<string>();
            list.AddFirst(item1);
            list.AddAfter(item1, item2);
            list.AddAfter(item2, item3);
            list.AddLast(item1);
