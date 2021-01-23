    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace ExcelHandlingTest
    {
      public class ExcelManager : IDisposable
      {
        Excel.Application m_excelApp = null;
        Process m_excelProcess = null;
        bool m_closeOnDispose = false;
        bool m_allowKillAll = false;
    
        public ExcelManager(bool useExistingInstance, bool closeOnDispose, bool visible, bool allowKillAll = false)
        {
          m_closeOnDispose = closeOnDispose;
          m_allowKillAll = allowKillAll;
    
          if (useExistingInstance)
          {
            try
            {
              m_excelApp = Marshal.GetActiveObject("Excel.Application") as Excel.Application;
            }
            catch (COMException ex)
            {
              m_excelApp = new Excel.Application();
            }
          }
          else
          {
            m_excelApp = new Excel.Application();
          }
          if (m_excelApp == null)
            throw new Exception("Excel may not be present on this machine");
    
          m_excelApp.Visible = visible;
    
          SetExcelProcess();
        }
    
        public Excel.Application Excel
        {
          get
          {
            return m_excelApp;
          }
        }
    
        [DllImport("User32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hwnd, out uint lpdwProcessId);
    
        private void SetExcelProcess()
        {
          uint processId = 0;
          GetWindowThreadProcessId((IntPtr)m_excelApp.Hwnd, out processId);
          m_excelProcess = Process.GetProcessById((int)processId);
        }
    
        private static List<int> GetExcelProcessIds()
        {
          return GetAllExcelProcesses().Select(p => p.Id).ToList();
        }
    
        public static void KillAllExcelProcesses()
        {
          foreach (Process p in GetAllExcelProcesses())
          {
            p.Kill();
          }
        }
    
        public static List<Process> GetAllExcelProcesses()
        {
          return (from p in Process.GetProcessesByName("Excel")
                  where Path.GetFileName(p.MainModule.FileName).Equals("Excel.exe", StringComparison.InvariantCultureIgnoreCase) &&
                  p.MainModule.FileVersionInfo.CompanyName.Equals("Microsoft Corporation", StringComparison.InvariantCultureIgnoreCase)
                  select p).ToList();
        }
    
        public event ExitStatusEventHandler ExitStatus;
        private void OnExitStatus(string status)
        {
          if (ExitStatus != null)
            ExitStatus(this, status);
        }
    
        public void Dispose()
        {
          if (m_excelProcess != null)
            OnExitStatus(string.Format("Process ID: {0}", m_excelProcess.Id));
          
          if (m_closeOnDispose)
          {
            if (m_excelApp != null)
              m_excelApp.Quit();
            m_excelApp = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Thread.Sleep(50);
    
            if (m_excelProcess != null)
            {
              List<Process> excelProcs = GetAllExcelProcesses();
              foreach (Process ep in excelProcs)
              {
                if (ep.MainWindowHandle == m_excelProcess.MainWindowHandle)
                {
                  ep.Kill();
                  ep.WaitForExit();
                  OnExitStatus("Exit by Kill");
                  m_excelProcess = null;
                  return;
                }
              }
            }
    
            if (m_allowKillAll)
            {
              List<Process> excelProcs = GetAllExcelProcesses();
              if (excelProcs != null && excelProcs.Count > 0)
              {
                KillAllExcelProcesses();
                OnExitStatus("Exit by Kill All");
                m_excelProcess = null;
                return;
              }
            }
    
            OnExitStatus("Exit by Quit");
            m_excelProcess = null;
          }
        }
      }
    
      public delegate void ExitStatusEventHandler(ExcelManager sender, string status);
    }
