    //First sorry for reusing your code but I am writing from my smartphone and 
    //I am kind of lazy here is quick modification that would work but not the most clever way around
        Thread sender = new Thread(voidSender);
        public static void voidSender()
        {
            start:
            serialArduino.WriteLine("Test");
            Thread.Sleep(2000);
            goto start;
        }
