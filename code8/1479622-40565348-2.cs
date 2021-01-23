     namespace Test
        {
            class EventSubscriber
            {       
                public HandlePeople(object o, RawPeopleDataEventArgs args)
                {
                    List<string> listofpeople = args.PeopleData;
                    printList(listofpeople);
                }
        
                void printList(List<string> print)
                {
                    print.ForEach(Console.WriteLine);
                    // More data processing to happen here
                }
            }
        }  
