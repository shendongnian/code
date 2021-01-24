    public LoginPageCS ()
    {
    	var toolbarItem = new ToolbarItem {
    		Text = "Sign Up"
    	};
    	toolbarItem.Clicked += OnSignUpButtonClicked;
    	ToolbarItems.Add (toolbarItem);
    
    	messageLabel = new Label ();
    	usernameEntry = new Entry {
    		Placeholder = "username"	
    	};
    	passwordEntry = new Entry {
    		IsPassword = true
    	};
    	var loginButton = new Button {
    		Text = "Login"
    	};
    	loginButton.Clicked += OnLoginButtonClicked;
    
    	Title = "Login";
    	Content = new StackLayout { 
    		VerticalOptions = LayoutOptions.StartAndExpand,
    		Children = {
    			new Label { Text = "Username" },
    			usernameEntry,
    			new Label { Text = "Password" },
    			passwordEntry,
    			loginButton,
    			messageLabel
    		}
    	};
    }
