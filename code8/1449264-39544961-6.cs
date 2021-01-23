    private static string generateItemClass(string className, string useBody)
    {
        return $@"
            public class {className} : BaseItem
            {{
                public override bool Use(object onMyObject)
                {{
                    {useBody}
                }}
            }}";
    }
