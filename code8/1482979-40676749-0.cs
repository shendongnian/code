            string Os = "Microsoft Windows 7 Professional 6.1.7601 Service Pack 1";
            string[] splitOs = Os.Split(null);
            foreach (var item in splitOs)
            {
                if (item.Contains("."))
                {
                    Version v1 = new Version(item)
                }
            }
