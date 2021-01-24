    public void execute()
            {
                var thread = new Thread(new ThreadStart(startAuthenticationProcess))
                {
                    IsBackground = true
                };
                thread.Start();
            }
     private void startAuthenticationProcess()
            {
                Thread.Sleep(2000);
                if (!Utils.isNetworkAvailable(splashActivity))
                {
                    splashActivity.RunOnUiThread(() => Utils.showToast(splashActivity, splashActivity.GetString(Resource.String.r30025)));
                    splashActivity.FinishAffinity();
                }
                else
                {
                    try
                    {
                        if (StringUtils.isBlank(strIPAdd) || (StringUtils.isNotBlank(strIPAdd) && (StringUtils.isBlank(strDbName) || "site".Equals(strDbName,StringComparison.OrdinalIgnoreCase))))
                        {
                            splashActivity.RunOnUiThread(() => DependencyService.Get<IAuthenticationDialog>().showAuthenticationDialog(new Command(() =>
                            {
                                var intent = new Intent(splashActivity, typeof(MainActivity));
                                intent.PutExtra("startLoginActivity", false);
                                splashActivity.StartActivity(intent);
                                splashActivity.Finish();
                            })));
                        }
                        else
                        {
                            gotoLoginScreen();
                        }
                    }
                    catch (Exception e)
                    {
                        Log.Error(TAG, e.Message);
                    }
                }
            }
