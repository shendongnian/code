    public async Task<ActionResult> Create(){
      List<Departments> departements = getDepartmentsFromDatabase();
    
      ArticleViewModel viewModel = new ArticleViewModel{
        Article = new Article(),
        Departments = departements.Select(x => new SelectListItem
                    {
                        Value = x.id.ToString(),
                        Text = x.DepartmentName
                    }).ToList()
      }
      return View(viewModel);
    }
