    public string Get( User user) {
        if (ModelState.IsValid && user != null) {
            // Do whatever You want with class
            String name = user.Name;
            String Car = user.Car;
        }
    }
