       //assuming
             public class User {
                	
    
                public string email;
            	public string password;
            
            	public User (string email, string password) {
            		this.email = email;
            		this.password = password;
            	}
            }
         
        //inside some class
            public void AddUser(){
              User user = new User("email@email.com", "password");
              string json = JsonUtility.ToJson(user);
              Firebase.Database.DatabaseReference dbRef = Firebase.Database.FirebaseDatabase.DefaultInstance.RootReference
              dbRef.Child("users").Push().SetRawJsonValueAsync(json);
            }
        
        	public void GetUsers(){
              Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
              dbInstance.GetReference("users").GetValueAsync().ContinueWith(task => {
        				if (task.IsFaulted) {
        					// Handle the error...
        				}
        				else if (task.IsCompleted) {
        				  DataSnapshot snapshot = task.Result;
                          foreach ( DataSnapshot user in snapshot.Children){
          				    IDictionary dictUser = (IDictionary)user.Value;
        				    Debug.Log ("" + dictUser["email"] + " - " + dictUser["password"]);
        			      }
        				}
        	  });
