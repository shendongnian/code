	IObservable<IList<MyData>> query =
		Observable
			.Using(() => new SqlConnection(""), connection =>
				Observable
					.Using(() => new SqlCommand("select * from MyTable", connection), cmd =>
						Observable
							.Using(() => cmd.ExecuteReader(), reader =>
								Observable
									.While(() => reader.Read(), Observable.Return(GetRow(reader))))))
			.Buffer(BatchSize);
			
	IDisposable subscription =
		query
			.Subscribe(async list => await WriteDataAsync(list));
