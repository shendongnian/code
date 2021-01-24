    public void DisTranswe()
        {
            Console.Clear();
            FileStream fs = new FileStream("TransactionHistory\\weekend\\transcationhistory.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            int sum=0;
            while ((str = sr.ReadLine()) != null)
            {
                string[] data = str.Split('#');
                string id = data[0];
                string date = data[1];
                string qty = data[2];
                string payment = data[3];
                string note = data[4];
                
                sum=sum+int.Parse(qty);
    
                //output
                Console.WriteLine("IdTransaksi");
                Console.WriteLine(id);
                Console.WriteLine("DateTransaksi");
                Console.WriteLine(date);
                Console.WriteLine("QOH");
                Console.WriteLine(qty);
                Console.WriteLine("TotalPayment");
                Console.WriteLine(payment);
                Console.WriteLine("Note");
                Console.WriteLine(note);
                
    
            }
            Console.WriteLine("SUM");
            Console.WriteLine(sum);
            sr.Close();
            fs.Close();
        }
