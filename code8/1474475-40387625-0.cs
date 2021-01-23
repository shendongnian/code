    List<AlumniJobPostViewModel> lst = new List<AlumniJobPostViewModel>(jobs);
    AlumniJobPostViewModel.Mode = mode;
    AlumniJobPostViewModel.SortOrder = sort;
    lst.Sort();
    uxPhotoGallery.DataSource = lst;
    uxPhotoGallery.DataBind();
    lblCount.Text = "" + uxPhotoGallery.Items.Count;
