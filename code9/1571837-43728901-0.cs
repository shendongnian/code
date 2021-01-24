    use messaging center here is the sample code 
    //for trigger
        MessagingCenter.Send<object> (this, "Hi");
    
    //put this where you want to receive your data
        MessagingCenter.Subscribe<object> (this, "Hi", (sender) => {
        // do something whenever the "Hi" message is sent
        });
