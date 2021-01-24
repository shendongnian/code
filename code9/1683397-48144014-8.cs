    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ContestLibrary
    {
        public class Heap
        {
            List<int> items;
    
            public int Root
            {
                get { return items[0]; }
            }
    
            public Heap()
            {
                items = new List<int>();
            }
    
            public int GetMin()
            {
                if(items.Count == 0)
                    throw new Exception("Empty Heap");
                return items[0];
            }
    
            public void Insert(int item)
            {
                items.Add(item);
                PercolateUpTheNode(items.Count - 1);
            }
    
            public void DeleteSpecificValueFromHeap(int val)
            {
                for (var i = 0; i < items.Count; i++)
                {
                    if (items[i] == val)
                    {
                        items[i] = items[items.Count - 1];
                        items.RemoveAt(items.Count - 1);
    
                        if (i == items.Count)
                            return;//cause you deleted the right most node
    
                        var parentNodeValue = items[(i - 1) / 2];
    
                        if (items[i] < parentNodeValue)
                            PercolateUpTheNode(i);
                        else
                            PercolateDownTheNode(i);
    
                        return;
                    }
                }
            }
    
            private void PercolateDownTheNode(int i)
            {
                while (i < items.Count / 2) {
                    //get the min child first
                    int minChildIndex = 2 * i + 1;
                    if (minChildIndex < items.Count - 1 && items[minChildIndex] > items[minChildIndex + 1]) {
                        minChildIndex++;
                    }
                    
                    if (items[i] <= items[minChildIndex])
                        return;//I'm smaller than the minimum of my children
    
                    //swap
                    int temp = items[i];
                    items[i] = items[minChildIndex];
                    items[minChildIndex] = temp;
    
                    i = minChildIndex;
                }
            }
    
            private int ParentIndex(int i)
            {
                return (i - 1) / 2;
            }
    
            private void PercolateUpTheNode(int i)
            {
                while (i > 0)
                {
                    var parentValue = items[ParentIndex(i)];
                    var currentValue = items[i];
    
                    if (currentValue < parentValue)//swap
                    {
                        items[ParentIndex(i)] = currentValue;
                        items[i] = parentValue;
                        i = ParentIndex(i);
                    }
                    else
                        return;
                }
            }
        }
    
        public class Problem
        {
    
            static void Main(string[] args)
            {
                Heap heap = new Heap();
                int q = int.Parse(Console.ReadLine());
                while (q-->0)
                {
                    var line = Console.ReadLine().Split();
                    int type = int.Parse(line[0]);
                    switch (type)
                    {
                            case 1:
                                heap.Insert(int.Parse(line[1]));
                            break;
                            case 2:
                                heap.DeleteSpecificValueFromHeap(int.Parse(line[1]));
                            break;
                            default:
                                Console.WriteLine(heap.GetMin());
                            break;
                    }
                }
            }
        }
    }
