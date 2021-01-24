    $http.post("AddProduct", clientSideVM)
       .then(function(response) { 
           // Access The Response Object
       }, function(error) {
           // Access The Error Object 
       });
    //Server Side Code
    //Exactly matching VM
    public class CustomViewModel {
       public string Name { get; set; }
       public string Description { get; set; }
       public List<ProductItems> Products { get; set; }
    }
 
    [HttpPost, Route("AddProduct")]
    public string AddProduct(CustomViewModel viewModel) {
      //here you have all you data from Client Side,
      var name = viewModel.Name;
      // Work on them here
      //Rest of your Code
    }
    
