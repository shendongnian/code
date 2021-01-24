            // Declaring the array
            int[] Weapon_Count;
            // Initializing the array with a size of 11
            Weapon_Count = new int[11];
            // Adding values to the array
            for (int i = 0; i < Weapon_Count.Length; i++)
            {
                Weapon_Count[i] = i + 100;
            }
            // Printing the values in the array
            for (int i = 0; i < Weapon_Count.Length; i++)
            {
                Console.WriteLine(Weapon_Count[i]);
            }
            // Same thing with a list
            // Daclare and initializing the List of integers
            List<int> weapon_list = new List<int>();
            // Adding some values 
            weapon_list.Add(1);
            weapon_list.Add(2);
            weapon_list.Add(3);
            weapon_list.Add(4);
            weapon_list.Add(5);
            // Printing weapin_list's values
            for (int i = 0; i < weapon_list.Count; i++)
            {
                Console.WriteLine(weapon_list[i]);
            }
            // This is just for the console to wait when you are in debug mode.
            Console.ReadKey();
