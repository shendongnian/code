        public IEnumerable<AppointmentModel> AddProducts(IEnumerable<AppointmentModel> apps)
        {
            var appointmentModels = apps as AppointmentModel[] ?? apps.ToArray();
            foreach (var app in appointmentModels)
            {
                var products = new List<ProductsEntity>
                {
                    new ProductsEntity {Id = "A", Desc = "ABC"},
                    new ProductsEntity {Id = "B", Desc = "ABC"},
                    new ProductsEntity {Id = "C", Desc = "ABC"}
                };
                app.Products = products; // Values are successfully getting assigned here
            }
            return appointmentModels; //apps.FirstOrDefault().Products is Null here
        }
