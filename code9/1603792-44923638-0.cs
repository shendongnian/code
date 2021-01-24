    StatusButton.Click += async (sender, e) =>
            {
    
                ...
    
                byte[] TheResponse = new byte[1024];
    
                TheResponse = await client.Read();          // <---- place await in the correct place
            };
