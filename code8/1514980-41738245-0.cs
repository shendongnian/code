    class A
    {
        public async processAndDouble(input: number): Promise<number>
        {
            try
            {
                //Sync method
                let processedInput = this.processDataSync(input);
                //Async method
                processedInput = await this.processDataAsync(processedInput);
                //Sync operation again
                return processedInput * 2;
            }
            catch (error)
            {
                return 0;
            }
        }
    
        public async processDataAsync(input: number): Promise<number>
        {
            if (input >= 0)
            { 
                //Do your async operation here
                return input + 1;
            }
            else
            {
                throw new Error("can't process negative numbers");
            }
        }
    
        public processDataSync(input: number): number
        {
            if (input >= 0)
            { 
                return input + 1;
            }
            else
            {
                throw new Error("can't process negative numbers");
            }
        }
    }
