        public async Task SomeWork()
        {
            while (someCondition)
            {
                //do some work
                await Task.Delay(100);//milliseconds
            }
        }
