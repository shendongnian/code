    public async override Task Invoke(IOwinContext context)
        {
            // here do your check!!
            if(isValid)
            {
                await Next.Invoke(context);
            }
            Console.WriteLine("End Request");
        }
