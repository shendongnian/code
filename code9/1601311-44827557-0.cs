    MyClass(string name, params object[] content)
    {
        this.name = name;
        this.children = new List<MyClass>();
        foreach (var arg in content)
        {
            if (arg is MyClass)
                children.Add(arg as MyClass);
            else if (arg is IEnumerable<MyClass>)
            {
                foreach (var element in args as IEnumerable<MyClass>)
                    children.Add(element);
            }
            else
                children.Add(new MyClass(arg.ToString()));
        }
    }
