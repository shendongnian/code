        @{
            var category = Request.QueryString["category"];
            var cat = Model.Items.Where(i => i.Id.ToString() == category).FirstOrDefault();
            if(cat==null)
            {
                <script>
                    function redirectIfNeeded(){
                        window.location = "@Url.Action()";   
                       // yes here using razor should be fine since it is just a line. 
                       //You can also hard code the url. 
                    }
                </script>
            }
        }
