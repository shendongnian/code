          public IHttpActionResult GetCompanies()
          {
              var companies = db.Companies.ToList();
              return Ok( new { results = companies });
          }
