    class Program
    {
        static T GetChoice<T>(List<Tuple<string, T>> choices)
        {
            var i = 1;
            choices.ForEach(x => Console.WriteLine($"[{i++}]: {x.Item1}"));
            var choiceIndex = int.Parse(Console.ReadLine());
            return choices[choiceIndex - 1].Item2;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main Menu: ");
            var choices = new List<Tuple<string, Action>>()
            {
                new Tuple<string, Action>("Show Activities", ShowActivities),
                new Tuple<string, Action>("Show Teachers", ShowTeachers),
                new Tuple<string, Action>("Show Students", ShowStudents),
                new Tuple<string, Action>("Exit", Exit),
            };
            GetChoice(choices)();
        }
        static void ShowActivities()
        {
            Console.WriteLine("Activities: ");
            var choices = new List<Tuple<string, Action>>()
            {
                new Tuple<string, Action>("Show all activities", ShowAllActivities),
                new Tuple<string, Action>("Find activity by code", FindActivityByCode),
                new Tuple<string, Action>("Return to main menu", () => { Main(null); }),
                new Tuple<string, Action>("Exit the program", Exit),
            };
            GetChoice(choices)();
        }
        static void ShowTeachers()
        {
            Console.WriteLine("Teachers: ");
            var choices = new List<Tuple<string, Action>>();
        }
        static void ShowStudents()
        {
            Console.WriteLine("Students: ");
            var choices = new List<Tuple<string, Action>>();
        }
        static void ShowAllActivities()
        {
            //Do stuff
        }
        static void FindActivityByCode()
        {
            //Do stuff
        }
        static void ReturnToMainMenu()
        {
            //Do stuff
        }
        static void Exit()
        {
            Environment.Exit(0);
        }
    }
