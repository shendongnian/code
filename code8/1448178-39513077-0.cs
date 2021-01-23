     var path = System.IO.Path.Combine(global::Android.OS.Environment.ExternalStorageDirectory.Path, "doc" + GlobalsAndroid.FixedDocumentationLanguageCode + ".pdf");
                                           
                                            var intent = new Intent(Intent.ActionView);
                                            global::Android.Net.Uri pdfFile = global::Android.Net.Uri.FromFile(new Java.IO.File(path));
                                            intent.SetDataAndType(pdfFile, "application/pdf");
                                            intent.SetFlags(ActivityFlags.GrantReadUriPermission);
                                            intent.SetFlags(ActivityFlags.NewTask);
                                            intent.SetFlags(ActivityFlags.ClearWhenTaskReset);
                                      
                                            this.StartActivity(intent);
 
