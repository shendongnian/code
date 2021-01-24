    Task.Run(() => {
    
                    SomeMethod(); //Some method that executes in background
    
                    //Popup when SomeMethod is finished using Fruchtzwerg answer
                    this.Invoke((MethodInvoker)delegate
                    {
                        PopupNotifier pop = new PopupNotifier();
                        pop.TitleText = "Test";
                        pop.ContentText = "Hello World";
                        pop.Popup();
                    });
                });
