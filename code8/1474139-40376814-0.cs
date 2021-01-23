       public Parent GetDetails()
       {
           //the following code should be replaced by the code to get Top parent details from your db or whatever. pass the children of this class to the below function
          Parent P=new Parent();
          P.Id=1;
          p.Name="Top";
          P.Children=new List<Parent>();
          P.Children.Add(new Parent(2,"test1"));
          P.Children.Add(new Parent(2,"test2"));
          P.Children.Add(new Parent(2,"test3"));
          P.Children=GetParendetails(P.Children);
          
       }
      
       public List<Parent> GetParendetails(List<Parent> PL)
       {
          if(PL!=null)
          {
              foreach(Parent P in PL)
              {
                 List<Parent> childlist=new List<Parent>();
                  //logic to get children of P and adding them to childlist
                   P.Children=GetParendetails(childlist);
              }
          }
          return PL;
       }
