    public void swap(DoubleLinkedList swapList, Node b, Node f) {
        Node a = b.PrevNode;
        Node c = b.NextNode;
        Node e = f.PrevNode;
        Node g = f.NextNode;
        if(swapList.First == b) {
            swapList.First = f;
        } else if(swapList.First == f) {
            swapList.First = b;
        }
        if(a != null) {
            a.NextNode = f;
        }
        f.PrevNode = a;
        f.NextNode = c;
        if(c != null) {
            c.PrevNode = f;
        }
        if(e != null) {
            e.NextNode = b;
        }
        b.PrevNode = e;
        b.NextNode = g;
        if(g != null) {
            g.PrevNode = b;
        }
        if(swapList.Last == b) {
            swapList.Last = f;
        } else if(swapList.Last == f) {
            swapList.Last = b;
        }
    }
