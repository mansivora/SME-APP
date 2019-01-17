using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace API_App.Models
{
    public class Function
    {
        public void LogFileWrite(string message)
        {
            FileStream fileStream = null;
            StreamWriter streamWriter = null;
            try
            {
                string logFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~\\ProgramLog\\"));
                message = "<Start Issue>" + System.DateTime.Now + "\t" + message + "\n <End Issue>";
                logFilePath = logFilePath + "ProgramLog" + "-" + DateTime.Today.ToString("yyyyMMdd") + "." + "txt";

                if (logFilePath.Equals("")) return;
                #region Create the Log file directory if it does not exists 
                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo = new FileInfo(logFilePath);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();


                #endregion Create the Log file directory if it does not exists

                if (!logFileInfo.Exists)
                {
                    fileStream = logFileInfo.Create();
                }
                else
                {
                    fileStream = new FileStream(logFilePath, FileMode.Append);
                }
                streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(message);
            }
            finally
            {
                if (streamWriter != null) streamWriter.Close();
                if (fileStream != null) fileStream.Close();
            }

        }
    }
}