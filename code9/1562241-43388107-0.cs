    [HttpPost]
    public ActionResult Sortie(ViewModel.DemandeViewModel postData) {
         int c = postData.CodeBarre; // assuming CodeBarre is an int in the ViewModel
         if ((int)TempData["codebarre"] == c) {
             // ...
         }
         // ...
    }
