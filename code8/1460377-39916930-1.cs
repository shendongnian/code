    var result = from s1 in db.Table1
                 where s1.Id == my_id
                 join s2 in db.Table2 on s1.Id equals s2.id_s1
                 join s3 in db.Table3 on s2.SomeProperty equals s3.SomeProperty
                 select new sampleDTO
                 {
                      User_Id = s1.User.Id,
                      ProdId = s2.ProdId,
                      //PropertyFromTable3 = s3.SomePropertyFromTable3
                 };
