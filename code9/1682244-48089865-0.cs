     class Program
    {
        static void Main(string[] args)
        {
            string UIName = "";
            string UIInvoice = "";
            string UIDue = "";
            string UIAmount = "";
            using (FileStream fs = new FileStream(@"C:/Accounts.txt", FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                string content = sr.ReadToEnd();
                string[] lines = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                int lineCount = 0;
                List<Account> accounts = new List<Account>();
                foreach (string line in lines)
                {
                    string[] column = line.Split(',');
                    if (lineCount != 0)
                    {
                        Account account = new Account();
                        account.AccountName = column[0];
                        account.InvoiceDate = column[1];
                        account.DueDate = column[2];
                        account.AmountDue = column[3];
                        accounts.Add(account);
                    }
                    lineCount++;
                }
                Console.WriteLine(content);
            }
            using (FileStream fs = new FileStream(@"C:/Accounts.txt", FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                Account account = new Account();
                account.AccountName = UIName;
                account.InvoiceDate = UIInvoice;
                account.DueDate = UIDue;
                account.AmountDue = UIAmount;
                //accounts.Add(account);
                Console.WriteLine("Would you like to enter additional data?");
                Console.WriteLine("Please enter the Account Name: ");
                UIName = Console.ReadLine();
                Console.WriteLine("Please enter the Invoice Date: ");
                UIInvoice = Console.ReadLine();
                Console.WriteLine("Please enter the Due Date: ");
                UIDue = Console.ReadLine();
                Console.WriteLine("Please enter the AmountDue: ");
                UIAmount = Console.ReadLine();
                string fullText = (UIName + "," + UIInvoice + "," + UIDue + "," + UIAmount);
                File.AppendAllText("C:/Accounts.txt", fullText + Environment.NewLine);//can't get this way working, even after switching "\"s to "/"s. It says that the file is being used by another process.
                Console.ReadLine();
            }
        }
    }
