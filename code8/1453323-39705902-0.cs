    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace test
    {
        public class Guy
        {
            private int m_ID;
            private int m_LifeExpectancy;
            private bool m_Living;
    
            public int ID
            {
                get { return m_ID; }
                set { m_ID = value; }
            }
            public int LifeExpectancy
            {
                get { return m_LifeExpectancy; }
                set { m_LifeExpectancy = value; }
            }
            public bool Living
            {
                get { return m_Living; }
                set { m_Living = value; }
            }
    
            public Guy(int id, int lifeExpectancy, bool living)
            {
                ID = id;
                LifeExpectancy = lifeExpectancy;
                Living = living;
            }
        }
    
        public class MyFactory
        {
            public IList<Guy> MakeSomeGuys(int howManyGuys)
            {
    
                IList<Guy> localGuys = new List<Guy>();
    
                for (int i = 0; i <= howManyGuys; i++)
                {
    
                    int id = i;
                    int lifeExpectancy = 80;
                    bool alive = true;
    
                    localGuys.Add(new Guy(id, lifeExpectancy, alive));
    
                    Console.WriteLine("Made a new Guy {0}", id);
                }
    
    
                return localGuys;
            }
        }
    
        public class program
        {
            public void Main()
            {
                MyFactory mf = new MyFactory();
                IList<Guy> guys = mf.MakeSomeGuys(5);
    
                //How do I access a specific object as well as its parameters? (Accessing from the list "Guys".)
                int GetFirstGuyId = guys.FirstOrDefault().ID; //LEARN LINQ
    
                //How do I access an object from this list in another class? (Not that I absolutely need to, I'm curious)
                //you need to learn about object oriented encapsulation for better understanding.
    
                //Can I search for an object in a list by using its parameters? (As opposed to doing something like...humanPopulation[number])
                Guy guyById = guys.Where(g => g.ID == 5).FirstOrDefault(); // returns the first match (need to learn lambda expression)
    
                //Should I create a new list for objects that have had their parameters modified? (As opposed to leaving it in the original list)
                // you need to learn about passing values by value / reference (by reference you already changing the original!).
    
                //Is it possible to remove items from a list? (Just in general, is that a thing people do? if so, why?)
                //yes
                guys.Remove(guyById);
    
            }
        }
    }
