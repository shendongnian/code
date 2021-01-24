     foreach (var uid in inbox.Search(query))
            {
                var message = inbox.GetMessage(uid);
               // Console.WriteLine("Subject: {0}", message.Subject);
                //Console.WriteLine("Subject: {0}", message.Headers);
               // Console.WriteLine("Subject: {0}", message.BodyParts);
                var text = message.BodyParts;
                string src = text.ElementAt(1).ToString();
                int srcStart = src.IndexOf("RFC822;",0); << i used final-recipient intially
                int srcEnd   = src.IndexOf("Action", 0);
                Console.WriteLine("Email:" + src.Substring(srcStart + 8, srcEnd - (srcStart + 8)));
                Console.WriteLine(src);
                //foreach (var part in message.BodyParts)
                //{
                //    Console.WriteLine(part);
                //    // do something
                //}
            }
