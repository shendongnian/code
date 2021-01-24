    class Program
    {
        static void Main(string[] args)
        {
            var str = "{Foo={name=Foo Value, active=true, some date=20170630}, Bar={name#=My Bar Value}, Key With Space={name=Foo Bar, active=false}}";
            var values = GetObjects(str);
            Dictionary<string, Dictionary<string, string>> objects = Merge(values);
        }
        public static Dictionary<string, Dictionary<string, string>> Merge(Dictionary<string, string> input)
        {
            var output = new Dictionary<string, Dictionary<string, string>>();
            foreach (var key in input.Keys)
            {
                var value = input[key];
                var subValues = GetValues(value);
                output.Add(key, subValues);
            }
            return output;
        }
        public static Dictionary<string, string> GetObjects(string input)
        {
            var objects = new Dictionary<string, string>();
            var objectNames = new Queue<string>();
            var objectBuffer = string.Empty;
            foreach (var c in input)
            {
                if (char.Equals('{', c))
                {
                    if (!string.IsNullOrEmpty(objectBuffer))
                    {
                        var b = objectBuffer.Trim('{', '}', ',', ' ', '=');
                        objectNames.Enqueue(b);
                    }
                    objectBuffer = string.Empty;
                }
                if (char.Equals('}', c))
                {
                    if (objectNames.Count > 0)
                    {
                        var b = objectBuffer.Trim('{');
                        var key = objectNames.Dequeue();
                        objects.Add(key, b);
                    }
                    objectBuffer = string.Empty;
                }
                objectBuffer += c;
            }
            return objects;
        }
        private static Dictionary<string, string> GetValues(string input)
        {
            var output = new Dictionary<string, string>();
            var values = input.Split(new string[] { ", " }, System.StringSplitOptions.None);
            foreach (var val in values)
            {
                var parts = val.Split('=');
                if (parts.Length == 2)
                {
                    var key = parts[0].Trim(' ');
                    var value = parts[1].Trim(' ');
                    output.Add(key, value);
                }
            }
            return output;
        }
    }
