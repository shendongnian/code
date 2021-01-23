    public class NodeInfo
    {
        public object Node { get; set; }
        public Queue<PropertyInfo> PropertiesToBeVisited{ get; set; }
    }
    public static class TypeExtensions
    {
        public static bool IsComplex(this Type type)
        {
            return !type.IsValueType && type != typeof(string);
        }
        public static bool IsCollection(this Type type)
        {
            var collectionTypeName = typeof(ICollection<>).Name;
            return type.Name == collectionTypeName || type.GetInterface(typeof(ICollection<>).Name) != null;
        }
    }
        public static void TraverseObjectTree(object data)
        {
            var currentNode = data;
            var currentNodeProperties = new Queue<PropertyInfo>(data.GetType().GetProperties());
            var nodeTracker = new Queue<NodeInfo>();
            while (currentNodeProperties.Count != 0 || nodeTracker.Count != 0)
            {
                if (currentNodeProperties.Count == 0 && nodeTracker.Count != 0)
                {
                    var currentNodeInfo = nodeTracker.Dequeue();
                    currentNode = currentNodeInfo.Node;
                    currentNodeProperties = currentNodeInfo.PropertiesToBeVisited;
                    continue;
                }
                var currentNodeProperty = currentNodeProperties.Dequeue();
                var currentNodePropertyType = currentNodeProperty.PropertyType;
                if (currentNodePropertyType.IsComplex())
                {
                    var value = currentNode?.GetType().GetProperty(currentNodeProperty.Name)
                        ?.GetValue(currentNode, null);
                    if (value != null)
                    {
                        object node;
                        if (currentNodePropertyType.IsCollection())
                        {
                            var elementType = currentNodePropertyType.IsArray
                                    ? value.GetType().GetElementType()
                                    : value.GetType().GetGenericArguments()[0];
                            node = Activator.CreateInstance(elementType ?? throw new InvalidOperationException());
                        }
                        else
                        {
                            node = value;
                        }
                        nodeTracker.Enqueue(new NodeInfo
                        {
                            Node = currentNode,
                            PropertiesToBeVisited = currentNodeProperties
                        });
                        currentNode = node;
                        currentNodeProperties = new Queue<PropertyInfo>(node.GetType().GetProperties());
                        Console.WriteLine(currentNodeProperty.Name);
                        continue;
                    }
                }
                Console.WriteLine(currentNodeProperty.Name);
            }
        }
