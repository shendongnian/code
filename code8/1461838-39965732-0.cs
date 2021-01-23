    public static void ShowCustomerInfo(PreferredCustomer customer)
        {
            using (var reader = new StreamReader("CustomerInfo.txt"))
            {
                var index = 0;
                preferredCustomers = new PreferredCustomer[5];
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Split(':');
                    var name = line[0];
                    var address = line[1];
                    var phone = line[2];
                    var id = line[3];
                    var email = line[4];
                    var spentAmount = Convert.ToInt32(line[5]);
                    var onEmailList = Convert.ToBoolean(line[6]);
                    preferredCustomers[index] = new PreferredCustomer(name, address, phone, id, email, spentAmount,
                        onEmailList);
                    index++;
                    Console.WriteLine("{0}:{1}:{2}:{3}:{4}:{5}:{6}",
                        name, address, phone, id, email, spentAmount,onEmailList);
                }
            }
        }
