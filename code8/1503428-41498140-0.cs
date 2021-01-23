     public void Call()
        {
            //Attach changes to context, Passing as reference
            Process(ref _context);
            //All changes attached to context
            _context.SaveChanges();
        }
        public void Process(ref Cliniciel_WebRV_MasterEntities context)
        {
            var c = context();
            //Get entites dbcontext
            //Update entites
        }
