        public static void ErrorMessage(string logMessage)
        {
            using (StreamWriter sw_errors = new StreamWriter(m_errors, true))  
            {
                sw_errors.Write("\r\nLog Entry : ");
                sw_errors.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                sw_errors.WriteLine("  :");
                sw_errors.WriteLine("  :{0}", logMessage);
                sw_errors.WriteLine("-------------------------------");
              
            }
        }
