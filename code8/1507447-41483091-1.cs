    var queryChuyenNganh = from t in myPhanLoaiTaiLieuDataContext.ChuyenNganhs
       join t0 in myPhanLoaiTaiLieuDataContext.BaiBaos
           on new { t.ChuyenNganhID } equals new { ChuyenNganhID = Convert.ToInt32(t0.ChuyenNganhID) } into t0_join
       from t0 in t0_join.DefaultIfEmpty()
       group new {T=t, NonNull=t0.ChuyenNganhID != null} by new
       {
           t.T.ChuyenNganhID,
           t.T.TenChuyenNganh
       } into g
       select new
       {
           ChuyenNganhID = (System.Int32)g.Key.ChuyenNganhID,
           g.Key.TenChuyenNganh,
           SoLuong  =(Int32)g.Count(x => x.NonNull)
       };
