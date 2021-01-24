    //Suppose YOur Lists are List1 and List2 then 
     If(Condition1==true)
     {
     List1   // Your datasource list
     List<dynamic> data = new List<dynamic>();
     foreach(var data in List1)
     {
     data.Add(new {  
     Name =data.Name, 
     Address = data.Address
     });
      }
     GridView1.DataSource = data 
     GridView1.DataBind();
     }
     ///For Condition 2
     If(Condition2==true)
     {
     List2   // Your second datasource list
     List<dynamic> data = new List<dynamic>();
     foreach(var data in List2){
     data.Add(new { 
     Name =data.Name, 
     Address = data.Address
    });
    }
    GridView1.DataSource = data 
    GridView1.DataBind();
    }
