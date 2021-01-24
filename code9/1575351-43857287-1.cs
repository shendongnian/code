    using System;
    namespace StackOverflow_Events
    {
        class Program
        {
            static void Main(string[] args)
            {
                string enumName = Enum.GetName(typeof(EnumPlayerStances), EnumPlayerStances.One_Handed_Sword).Replace("_", " ");
                int value = (int)EnumPlayerStances.One_Handed_Sword;
                var example = EnumPlayerStances.One_Handed_Sword;
                switch (example)
                {
                    case EnumPlayerStances.One_Handed_Sword:
                        // do stuff
                        break;
                }
                Console.WriteLine($"Name: {enumName}, Value: {value}");
                Console.ReadKey();
            }
        }
        public enum EnumPlayerStances
        {
            One_Handed_Sword = 50
        }
    }
