    var pList =from item in (from p in db.RTLS_PERSONDTLS
                 where (lsdAts <= p.CREATED_TIME && 
                 p.CREATED_TIME <= DateTime.Now)
                 where p.OPERATION_TYPE == 1
    
                 let pPhotoRow = (from q in db.Cloud_persons_images
                                 where q.Image_name == p.PERSON_ID
                                 where (lsdAts <= q.Createdtime && q.Createdtime <= DateTime.Now)
                                 select q).FirstOrDefault()
                              select new {
                                   p.MOBILE_NO,
                                   p.ACTINACT,
                                   Img_ext= pPhotoRow.Img_ext,
                                   photoBytes=pPhotoRow.Person_img
                                   }).ToList())                             )
    
                select new PersonListInfoDTO
                 {
                    MOB_NO = item.MOBILE_NO,
                    ACTINACT = (int)item.ACTINACT,
                    PHOTO = new PersonPhotoInfo { PDATA = Convert.ToBase64String(item.photoBytes), PEXT = pExt }
                 }).AsNoTracking().ToList();
