        if (!ModelState.IsValid)
        {
            var viewModel = new DoctorViewModel
            {
                Doctor = doctor
            };
            return View("Add", viewModel);
        }
