        List<string[]> logBook = new List<string[]> { };
            DateTime time = DateTime.Now;
            Console.WriteLine("\t" + time.ToShortDateString());
            Console.WriteLine("\n\tWelcome to the Logbook!\n");
            bool go = true;
            while (go)
                try
                {
                    {
                        Console.WriteLine("");  //Skapar ny rad. Användaren ska inte känna att det blandar ihop sig.
                        Console.WriteLine("\t[1] Write a new post");
                        Console.WriteLine("\t[2] Search for a post");
                        Console.WriteLine("\t[3] Display all posts");
                        Console.WriteLine("\t[4] Quit");
                        Console.Write("\n\tSelect from menu: ");
                        int menu = Convert.ToInt32(Console.ReadLine());  //Gör om inmatad sträng till heltal.
                        Console.WriteLine("");  //Skapar mellanrum innan nästa direktiv till användaren (Estetiskt).
                        switch (menu)
                        {
                            case 1:
                                string timeDate = time.ToShortDateString();
                                Console.Write("\tWrite a title to your post: ");
                                string title = Console.ReadLine();
                                Console.Write("\n\tPost is created " + timeDate + "\n\n\tWrite your post: ");
                                //Console.WriteLine("\t" + timeDate + "\n");
                                //Console.WriteLine("\t" + title + "\n\t");
                                string post = Console.ReadLine();
                                string[] arr = new string[3];
                                arr[0] = timeDate;
                                arr[1] = title;
                                arr[2] = post;
                                logBook.Add(arr);
                                break;
                            case 2:
                                Console.Write("\tWrite a searchword or a date (yyyy-mm-dd): ");
                                string keyword = Console.ReadLine();
                                Console.WriteLine("");
                                bool anyFound = false;
                                foreach (string[] item in logBook)  //För varje element(item) i Listan(logBook) dvs (arr[i])
                                {
                                    foreach (string element in item)  //För varje element(element) i arr[i] dvs (arr[0], arr[1], arr[2])
                                    {
                                        if (element.Contains(keyword))  // Om arr[0], arr[1] eller arr[2] innhåller sökord....
                                        {
                                            foreach (string s in item)  // Skriv ut varje arr[i] i det elementet(item) (dvs hela den loggen)
                                            {
                                                Console.WriteLine("\t" + s);
                                            }
                                            Console.WriteLine("");
                                            anyFound = true;
                                        }
                                    }
                                }
                                if (!anyFound)
                                    Console.WriteLine("\tSearchword couldn't be found.");
                                break;
                            case 3:
                                Console.WriteLine("\tThese are the current posts in Logbook.\n ");
                                foreach (var item in logBook)  //För varje element(item) i Listan(logBook) dvs (arr[i])
                                {
                                    foreach (string element in item)  //För varje element(element) i arr[i] dvs (arr[0], arr[1], arr[2])
                                    {
                                        Console.WriteLine("\t" + element);
                                    }
                                        Console.WriteLine("");
                                }
                                break;
                            default:
                                Console.WriteLine("\tChoose from menu 1 - 4");
                                break;
                            case 4:
                                go = false;
                                break;
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("");  //Estetisk för att användaren ska få ny rad innan meddelandet.
                    Console.WriteLine("\tChoose from menu by using number 1 - 4"); //Aktiveras om användaren knappar in annat än heltal.
                }
