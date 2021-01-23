		internal async Task<int> ExecuteNonQueryAsync(IOBehavior ioBehavior, CancellationToken cancellationToken)
		{
			using (var reader = (MySqlDataReader) await ExecuteReaderAsync(CommandBehavior.Default, ioBehavior, cancellationToken).ConfigureAwait(false))
			{
				do
				{
					while (await reader.ReadAsync(ioBehavior, cancellationToken).ConfigureAwait(false))
					{
					}
				} while (await reader.NextResultAsync(ioBehavior, cancellationToken).ConfigureAwait(false));
				return reader.RecordsAffected;
			}
		}
