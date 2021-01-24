                [HttpPost]
                [DisableFormValueModelBinding]
                public async Task<IActionResult> Upload()
                {
                    var viewModel = new MyViewModel();
                    try
                    {
                        FormValueProvider formModel;
                        using (var stream = System.IO.File.Create("c:\\temp\\myfile.temp"))
                        {
                            formModel = await Request.StreamFile(stream);
                        }
                        var bindingSuccessful = await TryUpdateModelAsync(viewModel, prefix: "",
                            valueProvider: formModel);
                        if (!bindingSuccessful)
                        {
                            if (!ModelState.IsValid)
                            {
                                return BadRequest(ModelState);
                            }
                        }
                    }
                    catch(Exception exception)
                    {
                        throw;
                    }
                    return Ok(viewModel);
                }
