     static void Main(string[] args)
        {
            Customer cu = new Customer();
            Client cl = new Client();
            //usage of is 
            var flag = cu is Customer;
            Console.WriteLine(flag); //true
            flag = cu is Client;
            Console.WriteLine(flag); // false
            //convert it to a dynamic object
            dynamic obj = cu;
            //usage of as
            var obj1 = obj as Customer;
            Console.WriteLine(obj);
            //on the below statement, I was expecting an exception on run time.#
            var obj2 = obj as Client;
            Console.WriteLine(obj2);            // <-- this is null!!
            //#checkPoint but the above line is giving me Compile time error.
            Console.ReadKey();
        }
