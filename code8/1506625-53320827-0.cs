    public void Generate(int numberOfItems = 1, ItemOptions options = ItemOptions.NONE)
        {
            try
            {
                Type t = typeof(T);
                if (t == typeof(Item))
                    throw new ArgumentException("Type " + t + " is not valid for generation.  Please contact QA.");
                else
                    Parallel.For(0, numberOfItems, (i, loopState) =>
                    {
                        try
                        {
                            GenerateItemByType(typeof(T), options);
                        }
                        catch
                        {
                            loopState.Stop();
                            throw;
                        }
                    });
            }
            catch (AggregateException ae)
            {
                ae.Handle((x) =>
                {
                    if (x is SQLNullResultsException)
                    {
                        throw x;
                    }
                    else if (x is ImageNotTIFFException)
                    {
                        throw x;
                    }
                    else
                    {
                        throw x;
                    }
                    return true;
                });
            }
            catch
            {
                throw;
            }
            finally
            {
                ItemManager.Instance.Clear();
            }
        }
        private void GenerateItemByType(Type t, ItemOptions options = ItemOptions.NONE)
        {
            try
            {
                if (t == typeof(ItemA))
                {
                    if ((options & ItemOptions.DUPLICATE) != 0)
                    {
                        this.Enqueue(new ItemB(options));
                    }
                    else
                    {
                        this.Enqueue(new ItemA(options));
                    }
                }
                else if (t == typeof(ItemC))
                {
                    this.Enqueue(new ItemC(options));
                }
            }
            catch
            {
                throw;
            }
            finally { }
        }
