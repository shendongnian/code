        public Class MyViewModelClass
        {
           List<Movie> MoviesList {get;set;}
           List<SelectListItem> StatesList {get;set;}
           //some other properties/methods can go here as well ...
        }
        //In Controller
        {
            MyViewModelClass model = new MyViewModelClass();
            model.StatesList = <build your select list>;
            model.MovieList = <build your movie list>;
   
            return View(model);
        }
