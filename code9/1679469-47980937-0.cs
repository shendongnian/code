    public void Worker(object sender, DoWorkEventArgs e)
    {
        // ...
        workerBlock = new ActionBlock<ValidationObject>(
          (arg) => Validate(arg), // This line #1
          new ExecutionDataflowBlockOptions
          {
              MaxDegreeOfParallelism = 5
          });
        // ...
    }
    private void Validate(ValidationObject validationObject) // This line #2
    {
        try
        {
            using (var contactUnitOfWork = _unitOfWorkManager2.Begin(TransactionScopeOption.RequiresNew))
            {
                Contact contact = validationObject.Contact;
                contact.IsChecked = true;
                AsyncHelper.RunSync(async () => // This line #3
                {                               // This line #4
                    await _contactRepository.UpdateAsync(contact);
                    await contactUnitOfWork.CompleteAsync();
                });                             // This line #5
            }
        } catch (Exception ex) {
            Logger.Error(ex.ToString());
            throw;
        }
    }
