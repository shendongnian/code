    static void Main(string[] args)
            {
                PersonList listOfPerson = new PersonList();
                listOfPerson.Add(new person() { age = 25, name = "jhon" });
                listOfPerson.Add(new person() { age = 26, name = "jhon" });
                listOfPerson.Add(new person() { age = 21, name = "homer" });
                listOfPerson.Add(new person() { age = 22, name = "bill" });
                listOfPerson.Add(new person() { age = 27, name = "jhon" });
                listOfPerson.Add(new person() { age = 22, name = "andrew" });
    
                foreach (var item in listOfPerson.getAge2("jhond"))
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
