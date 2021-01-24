    all = db.Certifications.ToList()
          .Select(c => new CertificationListViewModel {
              SomeProperty = c.SomeProperty,
              AnotherProperty = c.AnotherProperty
          });
