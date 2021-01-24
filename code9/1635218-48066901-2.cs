     public async Task<IResult> ExecuteAsync(TCommand command,
            CancellationToken token = default(CancellationToken))
        {
            try
            {
                return await _commandHandler.ExecuteAsync(command, token).ConfigureAwait(false);
            }
            catch (UserFriendlyException ex)
            {
                await _logger.LogAsync(new LogEntry(LogTypeEnum.Error, _userContext,
                        "Friendly exception with command: " + typeof(TCommand).FullName, ex, command), token)
                    .ConfigureAwait(false);
                return ResultHelper.Error(ex.Message);
            }
            catch (DataNotFoundException ex)
            {
                await _logger.LogAsync(new LogEntry(LogTypeEnum.Error, _userContext,
                        "Data Not Found exception with command: " + typeof(TCommand).FullName, ex, command), token)
                    .ConfigureAwait(false);
                return ResultHelper.NoDataFoundError();
            }
            catch (ConcurrencyException ex)
            {
                await _logger.LogAsync(new LogEntry(LogTypeEnum.Error, _userContext,
                        "Concurrency error with command: " + typeof(TCommand).FullName, ex, command), token)
                    .ConfigureAwait(false);
                return ResultHelper.ConcurrencyError();
            }
            catch (Exception ex)
            {
                await _logger.LogAsync(new LogEntry(LogTypeEnum.Error, _userContext,
                    "Error with command: " + typeof(TCommand).FullName, ex, command), token).ConfigureAwait(false);
                return ResultHelper.Error(CommonResource.Error_Generic);
            }
        }
