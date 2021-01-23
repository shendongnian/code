    public class flattenedList
    {
        public string whatever;
        public int whateverInt;
    }
    public class nested
    {
        private Dictionary<string, List<flattenedList>> listData = new Dictionary<string, List<flattenedList>>();
        private List<ClassA> list1 = new List<ClassA>();
        ClassA classA = new ClassA();
        ClassB classB = new ClassB();
        ClassC classC = new ClassC();
        public void processCalsses()
        {
            string key = "";
            foreach (ClassA a in list1)
            {
                key = "ClassA.ClassBList";
                foreach (ClassB b in classA.classBList)
                {
                    addToDictionary(key, new flattenedList() { whatever = b.otherThing, whateverInt = b.somethingElse });
                }
                key = "ClassA.ClassCList";
                foreach (ClassC c in classA.classCList)
                {
                    addToDictionary(key, new flattenedList() { whatever = c.somethingB, whateverInt = c.somethingA });
                }
                addToDictionary("ClassA", new flattenedList() { whatever = a.something, whateverInt = a.whatever });
            }
            key = "ClassB.ClassCList";
            foreach (ClassC c in classB.classCList)
            {
                addToDictionary(key, new flattenedList() { whatever = c.somethingB, whateverInt = c.somethingA });
            }
            addToDictionary("ClassB", new flattenedList() { whatever = classB.otherThing, whateverInt = classB.somethingElse });
            addToDictionary("ClassC", new flattenedList() { whatever = classC.somethingB, whateverInt = classC.somethingA });
            foreach (KeyValuePair<string, List<flattenedList>> kvp in listData)
            {
                for (int i = 0; i < kvp.Value.Count; i++)
                {
                    Console.WriteLine(key + "[" + i.ToString() + "] whatever = " + kvp.Value[i].whatever);
                    Console.WriteLine(key + "[" + i.ToString() + "] whateverInt = " + kvp.Value[i].whateverInt.ToString() + "\n");
                }
            }
        }
        private void addToDictionary(string key, flattenedList f)
        {
            if (!listData.ContainsKey(key))
            {
                listData.Add(key, new List<flattenedList>());
            }
            listData[key].Add(f);
        }
        public class ClassA
        {
            public List<ClassB> classBList = new List<ClassB>();
            public List<ClassC> classCList;
            public int whatever;
            public string something;
        }
        public class ClassB
        {
            public List<ClassC> classCList;
            public int somethingElse;
            public string otherThing;
        }
        public class ClassC
        {
            public int somethingA;
            public string somethingB;
        }
    }
