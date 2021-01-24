	var pQuery = Query.Empty;
	for (int i = 0; i < interests.Count; i++) {
		var cQuery = Query.And(
			Query<Product>.EQ(u => u.productCategory, interests[i].Name),
			Query<Product>.ElemMatch(f => f.features, e => Query.And(
				Query<ProductFeature>.In(u => u.feature, interests[i].Features),
				Query<ProductFeature>.GT(u => u.rating, 5))));
		pQuery = Query.And(pQuery, cQuery);
	}
	var result = collection.Find(pQuery).SetLimit(20);
	}
