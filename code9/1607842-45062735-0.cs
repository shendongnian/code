    var result = from cust in tblCust.AsEnumerable()
             join mat in tblMat.AsEnumerable()
             new { coil_id = (string)cust["coil_id"], order_id = (string)cust["order_id"] }
             equals
             new { coil_id = (string)mat["PIECE_ID"], order_id = (string)mat["PRODUCTION_ORDER_ID"] }
                                 join parts in tblParts.AsEnumerable() on (string)mat["PIECE_ID"] equals (string)parts["ProdCoilNo"]
             select new
             {
                 coil_id = mat["PIECE_ID"]?? String.Empty,
                 order_id = mat["PRODUCTION_ORDER_ID"]?? String.Empty,
                 part = parts["PartNumber"]?? String.Empty,
                 gauge = mat["THICKNESS"]?? String.Empty,
                 width = mat["WIDTH"]?? String.Empty,
                 weight = mat["WEIGHT"]?? String.Empty,
                 code = mat["MATERIAL_BLOCK_STATE"]?? String.Empty,
                 requestor_comment = cust["requestor_comment"]?? String.Empty,
                 requestor = cust["requestor"]?? String.Empty,
                 updated_by_comment = cust["updated_by_comment"]?? String.Empty,
                 updated_by_user = cust["updated_by_user"]?? String.Empty                                     
             };
