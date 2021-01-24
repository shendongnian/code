    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp3
    {
        class Program
        {
            public class Test
            {
                public static IEnumerable<Item> ItemDescendents(IEnumerable<Item> src, int parent_id)
                {
                    foreach (var item in src.Where(i => i.Id_Parent == parent_id))
                    {
                        yield return item;
                        foreach (var itemd in ItemDescendents(src, item.Id))
                            yield return itemd;
                    }
                }
    
                public static IEnumerable<Item> ItemDescendentsFlat(IEnumerable<Item> src, int parent_id)
                {
                    void PushRange<T>(Stack<T> s, IEnumerable<T> Ts)
                    {
                        foreach (var aT in Ts)
                            s.Push(aT);
                    }
    
                    var itemStack = new Stack<Item>(src.Where(i => i.Id_Parent == parent_id));
    
                    while (itemStack.Count > 0)
                    {
                        var item = itemStack.Pop();
                        PushRange(itemStack, src.Where(i => i.Id_Parent == item.Id));
                        yield return item;
                    };
                }
    
                public IEnumerable<Item> ItemDescendantsFlat2(IEnumerable<Item> src, int parent_id)
                {
                    var children = src.Where(s => s.Id_Parent == parent_id);
                    do
                    {
                        foreach (var c in children)
                            yield return c;
                        children = children.SelectMany(c => src.Where(i => i.Id_Parent == c.Id));
                    } while (children.Count() > 0);
                }
    
                public IEnumerable<Item> ItemDescendantsFlat3(IEnumerable<Item> src, int parent_id)
                {
                    var childItems = src.ToLookup(i => i.Id_Parent);
    
                    var children = childItems[parent_id];
                    do
                    {
                        foreach (var c in children)
                            yield return c;
                        children = children.SelectMany(c => childItems[c.Id]);
                    } while (children.Count() > 0);
                }
    
                public IEnumerable<Item> ItemDescendantsFlat4(IEnumerable<Item> src, int parent_id)
                {
                    var childItems = src.ToLookup(i => i.Id_Parent);
    
                    var stackOfChildren = new Stack<IEnumerable<Item>>();
                    stackOfChildren.Push(childItems[parent_id]);
                    do
                        foreach (var c in stackOfChildren.Pop())
                        {
                            yield return c;
                            stackOfChildren.Push(childItems[c.Id]);
                        }
                    while (stackOfChildren.Count > 0);
                }
    
                public static int GetSum(IEnumerable<Item> items, int id)
                {
                    // add all matching items
                    var itemsToSum = items.Where(i => i.Id == id).ToList();
                    var oldCount = 0;
                    var currentCount = itemsToSum.Count();
                    // it nothing was added we skip the while
                    while (currentCount != oldCount)
                    {
                        oldCount = currentCount;
                        // find all matching items except the ones already in the list
                        var matchedItems = items
                            .Join(itemsToSum, item => item.Id_Parent, sum => sum.Id, (item, sum) => item)
                            .Except(itemsToSum)
                            .ToList();
                        itemsToSum.AddRange(matchedItems);
                        currentCount = itemsToSum.Count;
                    }
    
                    return itemsToSum.Sum(i => i.Price);
                }
    
                /// <summary>
                /// Implements a recursive function that takes a single parameter
                /// </summary>
                /// <typeparam name="T">The Type of the Func parameter</typeparam>
                /// <typeparam name="TResult">The Type of the value returned by the recursive function</typeparam>
                /// <param name="f">The function that returns the recursive Func to execute</param>
                /// <returns>The recursive Func with the given code</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static Func<T, TResult> Y<T, TResult>(Func<Func<T, TResult>, Func<T, TResult>> f)
                {
                    Func<T, TResult> g = null;
                    g = f(a => g(a));
                    return g;
                }
    
    
                public IEnumerable<Item> GetDescendants(IEnumerable<Item> items, int key)
                {
                    var lookup = items.ToLookup(i => i.Id_Parent);
                    Stack<Item> st = new Stack<Item>(lookup[key]);
    
                    while (st.Count > 0)
                    {
                        var item = st.Pop();
                        yield return item;
                        foreach (var i in lookup[item.Id])
                        {
                            st.Push(i);
                        }
                    }
                }
    
                public class Item
                {
                    public int Id;
                    public int Price;
                    public int Id_Parent;
                }
    
                protected Item[] getItems(int count, bool wide)
                {
                    Item[] Items = new Item[count];
                    for (int i = 0; i < count; ++i)
                    {
                        Item ix = new Item()
                        {
                            Id = i,
                            Id_Parent = wide ? i / 2 : i - 1,
                            Price = i % 17
                        };
                        Items[i] = ix;
                    }
                    return Items;
                }
    
                public void test()
                {
                    Item[] items = null;
    
                    int CalculatePrice(int id)
                    {
                        int price = items.Where(item => item.Id_Parent == id).Sum(child => CalculatePrice(child.Id));
                        return price + items.First(item => item.Id == id).Price;
                    }
    
                    var functions = new List<(Func<Item[], int, int>, string)>() {
                    ((it, key) => ItemDescendents(it, key).Sum(i => i.Price), "ItemDescendents"),
                    ((it, key) => ItemDescendentsFlat(it, key).Sum(i => i.Price), "ItemDescendentsFlat"),
                    ((it, key) => ItemDescendantsFlat2(it, key).Sum(i => i.Price), "ItemDescendentsFlat2"),
                    ((it, key) => ItemDescendantsFlat3(it, key).Sum(i => i.Price), "ItemDescendentsFlat3"),
                    ((it, key) => ItemDescendantsFlat4(it, key).Sum(i => i.Price), "ItemDescendentsFlat4"),
                    ((it, key) => CalculatePrice(key), "CalculatePrice"),
                    ((it, key) => Y<int, int>(x => y =>
                    {
                        int price = it.Where(item => item.Id_Parent == y).Sum(child => x(child.Id));
                        return price + it.First(item => item.Id == y).Price;
                    })(key), "Y"),
                    ((it, key) => GetSum(it, key), "GetSum"),
                    ((it, key) => GetDescendants(it, key).Sum(i => i.Price), "GetDescendants" )                 
                    };
    
                    System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
    
                    var testSetup = new[]
                    {
                        new { Count = 10, Wide = true, Key=3}, //warmup
                        new { Count = 100000, Wide = true, Key=3},
                        new { Count = 3000, Wide = false, Key=3}
                    };
    
                    List<int> sums = new List<int>();
                    foreach (var setup in testSetup)
                    {
                        items = getItems(setup.Count, setup.Wide);
                        Console.WriteLine("---------- " + (setup.Wide ? "Wide" : "Narrow")
                            + " " + setup.Count + " " + setup.Key + " ----------");
                        foreach (var func in functions)
                        {
                            st.Restart();
                            sums.Add(func.Item1(items, setup.Key));
                            st.Stop();
                            Console.WriteLine(func.Item2 + ": " + st.ElapsedMilliseconds + "ms");
                        }
                        Console.WriteLine();
                        Console.WriteLine("checks: " + string.Join(", ", sums));
                        sums.Clear();
                    }
    
                    Console.WriteLine("---------- END ----------");
    
                }
            }
    
            static void Main(string[] args)
            {
                Test t = new Test();
                t.test();
            }
        }
    }
