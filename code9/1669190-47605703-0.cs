                    string[] testfiles = file.FileName.Split(new char[] { '\\' });
                    fname = DateTime.Now.ToString("ddMMMyyyyhhmissmmm") + testfiles[testfiles.Length - 1];
                    filename = filename + Path.GetFileName(fname);
                }
                else
                {
                    fname = DateTime.Now.ToString("ddMMMyyyyhhmissmmm") + file.FileName;
                    filename = filename + Path.GetFileName(fname);
                }
                string replacestr = System.Text.RegularExpressions.Regex.Replace(filename, "[^a-zA-Z0-9_]+", " ");
                fname = replacestr;
                fname = replacestr;
                fname = fname.Replace(" ", "").Replace(",", "").Trim();
                fname = fname + "";
                fname = fname + ".png";
                filename = fname;
                fname = Path.Combine(context.Server.MapPath("../admin/img/product_images/"), fname);
                file.SaveAs(fname);
