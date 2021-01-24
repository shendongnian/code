        [HttpPost]
        public IActionResult MyModelPost(MyModel model,string extraParam){
            Debug.WriteLine($"model param {model.Name}");
            Debug.WriteLine($"extra param {extraParam}");
            return View();
            //out put:
            // model param adsfs
            // extra param extra value
        }
