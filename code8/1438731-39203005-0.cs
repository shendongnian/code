    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    namespace Linked_List
    {
    public unsafe class NodeList
    {
        public static Node * head ;
        public void AddNode(int d)
        {
            Node* newNode = (Node*)Marshal.AllocHGlobal(sizeof(Node)).ToPointer();
            newNode->data = d;
            newNode->link = null;
            Node* temp;
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                temp = head;
                head = newNode;
                newNode->link = temp;
            }
            Console.WriteLine(head->data);
        }
        public void TraverseNodes()
        {
            Node* temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp->data);
                temp = temp->link;
            }
        }
    }
    public unsafe struct Node
    {
        public int data;
        public Node* link;
    }
    unsafe class  Program
    {
        private  static void UnsafeDSImplementation()
        {
            var myLinkedList = new NodeList();
            myLinkedList.AddNode(2);
            myLinkedList.AddNode(4);
            myLinkedList.TraverseNodes();
        }
        static void Main(string[] args)
        {
            UnsafeDSImplementation();
        }
    }
}
