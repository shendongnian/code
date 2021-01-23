    System.Collections.Generic.IEnumerable<Test> lResultFromServer = ...;
    lResultFromServer.SelectMany(s =>
      s.subTest.Select(st => new System.Web.Mvc.SelectListItem {
        Group=new System.Web.Mvc.SelectListGroup {Name = s.Name}, Value=st.Id, Text=st.value
      })
    );
