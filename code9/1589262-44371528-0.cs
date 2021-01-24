    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    namespace FindingClosestObjectInList
    {
        class exampleObject
        {
            public float value;
        }
        class Program
        {
            static void Main(string[] args)
            {
                //Generate objectList with some random value
                var objectList = new SortedList<float, exampleObject>();
                var rnd = new Random();
                for (int i = 0; i < 10000; i++)
                {
                    var o = new exampleObject();
                    o.value = (float)(rnd.NextDouble()); 
                    //Values need to be Unique, that might be a problem for you.
                    if (!objectList.Keys.Contains(o.value))
                    {
                        objectList.Add(o.value, o);
                    }
                }
                float target = .314f;
                var closestToTarget = objectList.Keys.FindClosest(target);
                Console.WriteLine(closestToTarget);
                Console.ReadKey();
            }
        }
        public static class ExtensionMethod
        {
            public static T FindClosest<T>(this IList<T> sortedCollection, T target) 
                where T : IComparable<T>, IConvertible
            {
                //Initialize borders for binary search
                int begin = 0;
                int end = sortedCollection.Count;
                T lastElement = target;
                while (end > begin)
                {
                    int index = (begin + end) / 2;
                    lastElement = sortedCollection[index];
                    //Small change to binary search, to make sure we pick the closer one,
                    //when we two values left.
                    if (end - begin == 2)
                    {
                        //Distanzes between the two values and the 
                        var a = sortedCollection[begin];
                        var b = sortedCollection[begin + 1];
                        var aDist = substractGeneric(a, target);
                        var bDist = substractGeneric(b, target);
                        return a.CompareTo(b) <= 0 ? a : b;
                    }
                    //Actual binary search
                    if (lastElement.CompareTo(target) >= 0)
                        end = index;
                    else
                        begin = index + 1;
                }
                //Normal ending of binary search.
                return lastElement;
            }
            //If your Type that doesn't support substraction, this will explode at RUNTIME.
            public static T substractGeneric<T>(T a, T b)
                where T : IConvertible  //Will make it more difficult to call this function with stupid Ts, but might still explode.
            {
                return (dynamic)a - (dynamic)b;
            }
        }
    }
