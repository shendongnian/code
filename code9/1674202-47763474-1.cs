    List<GetList> listImg = new List<GetList>();
    foreach(var docs in Doc)
         {
             GetList gl = new GetList();
              gl.id = 1  // assuming an id to 1
              gl.thisImage = docs.Images //if this is a true image
              listImg.Add(gl);
         }
