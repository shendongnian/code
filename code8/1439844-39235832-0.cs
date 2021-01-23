    using System;
    namespace Program
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                division d = new division();
                d.CreateDivisionStructure();
                Console.ReadLine();
            }
        }
        internal class division
        {
            private static int CountHowManyTimesMyVarWasInitilized = 0;
         
            public division()
            {
            }
            protected string _myVar;
            protected bool _isReadyForInitialization;
            public string myVar
            {
                get
                {
                    if (!_isReadyForInitialization)
                        return null;
                    if (_myVar == null)
                    {
                    
                        CountHowManyTimesMyVarWasInitilized++;
                        Console.WriteLine(CountHowManyTimesMyVarWasInitilized);
                        _myVar = "now myVar is not null";
                        return _myVar;
                    }
                    else
                    { return _myVar; }
                }
                set { _myVar = value; }
            }
            public void CreateDivisionStructure()
            {
                // now _myVar is spposed to be initilized to all dirved clasess isnt is?
                Console.WriteLine(myVar);
                for (int i = 0; i < 7; i++)
                {
                    Branch b = new Branch(7);
                }
                _isReadyForInitialization = true;
                Console.WriteLine(myVar);
            }
        }
        internal class Branch : division
        {
            public Branch(bool dImDerivedClass)
            {
                //  constructor for department to prevent recursive stackoverflow if base of department will call the empty constructor
            }
            public Branch(int NumberOfBranches)
            {
                Console.WriteLine(myVar);
                Department d = new Department(7);
            }
        }
        internal class Department : Branch
        {
            public Department(bool ImDerivedClass) : base(true)
            {
                //  constructor for team to prevent recursive stackoverflow if base of Team will call the empty constructor
            }
            public Department(int numberOfDep) : base(true)
            {
                for (int i = 0; i < numberOfDep; i++)
                {
                    Console.WriteLine(myVar);
                    Team t = new Team(7);
                }
            }
        }
        internal class Team : Department
        {
            public Team():base(false)
            {
                _isReadyForInitialization = true;
            }
            public Team(int numberOfTeams) : base(true)
            {
                for (int i = 0; i < numberOfTeams; i++)
                {
                    Console.WriteLine(myVar);
                }
            }
        }
    }
