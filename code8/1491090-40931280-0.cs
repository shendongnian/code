            OutlookNS = Globals.ThisAddIn.Application.GetNamespace("MAPI");
            Outlook.MAPIFolder f = OutlookNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar);
            Outlook.CalendarSharing cs = f.GetCalendarExporter();
            cs.CalendarDetail = Outlook.OlCalendarDetail.olFullDetails;
            cs.StartDate = new DateTime(2015, 11, 1);
            cs.EndDate = new DateTime(2016, 12, 31);
            cs.SaveAsICal(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\kalender.ics");
