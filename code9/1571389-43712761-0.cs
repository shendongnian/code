        listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:8000/");
        listener.Prefixes.Add("http://127.0.0.1:8000/");
        listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
    
        listener.Start();
        this.listenThread1 = new Thread(new ParameterizedThreadStart(startlistener));
        listenThread1.Start();
    }
