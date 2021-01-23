csharp
public static class EnumerableExtensions
{
    public static List<T> ToRecursiveOrderList<T>(this IEnumerable<T> collection, Expression<Func<T, IEnumerable<T>>> childCollection)
    {
        var resultList = new List<T>();
        var currentItems = new Queue<(int Index, T Item, int Depth)>(collection.Select(i => (0, i, 0)));
        var depthItemCounter = 0;
        var previousItemDepth = 0;
        var childProperty = (PropertyInfo)((MemberExpression)childCollection.Body).Member;
        while (currentItems.Count > 0)
        {
            var currentItem = currentItems.Dequeue();
            // Reset counter for number of items at this depth when the depth changes.
            if (currentItem.Depth != previousItemDepth) depthItemCounter = 0;
            var resultIndex = currentItem.Index + depthItemCounter++;
            resultList.Insert(resultIndex, currentItem.Item);
            var childItems = childProperty.GetValue(currentItem.Item) as IEnumerable<T> ?? Enumerable.Empty<T>();
            foreach (var childItem in childItems)
            {
                currentItems.Enqueue((resultIndex + 1, childItem, currentItem.Depth + 1));
            }
            previousItemDepth = currentItem.Depth;
        }
        return resultList;
    }
}
Here is an example of how to use it. A structure like this will be flattened.
- A
- B
- C
    - D
        - E
    - F
    - G
    - H
        - I
- J
    - K
    - L
        - M
- N
- O
    - P
    - Q
        - R
        - S
    - T
csharp
internal class Alpha
{
    public string Value { get; set; }
    public Alpha[] Children { get; set; }
    public override string ToString() => Value;
}
internal class Program
{
    public static void Main()
    {
        var items = new []
        {
            new Alpha { Value = "A" },
            new Alpha { Value = "B" },
            new Alpha { Value = "C", Children = new []
            {
                new Alpha { Value = "D", Children = new []
                {
                    new Alpha { Value = "E" },
                }},
                new Alpha { Value = "F" },
                new Alpha { Value = "G" },
                new Alpha { Value = "H", Children = new []
                {
                    new Alpha { Value = "I" },
                }},
            }},
            new Alpha { Value = "J", Children = new []
            {
                new Alpha { Value = "K" },
                new Alpha { Value = "L", Children = new []
                {
                    new Alpha { Value = "M" },
                }},
            }},
            new Alpha { Value = "N" },
            new Alpha { Value = "O", Children = new []
            {
                new Alpha { Value = "P" },
                new Alpha { Value = "Q", Children = new []
                {
                    new Alpha { Value = "R" },
                    new Alpha { Value = "S" },
                }},
                new Alpha { Value = "T" },
            }},
        };
        var ordered = items.ToRecursiveOrderList(a => a.Children);
        foreach (var item in ordered)
        {
            Console.WriteLine(item);
        }
    }
}
The output looks like this:
A
B
C
D
E
F
G
H
I
J
K
L
M
N
O
P
Q
R
S
T
