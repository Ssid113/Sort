using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Diagnostics;


namespace SortFile
{
    /// <summary>
    /// 
    /// </summary>
    public partial class App : Application
    {

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length !=0)
            {
                if (e.Args[0] == "afterup")
                {
                    File.Delete("Update.exe");
                }
                if (e.Args[0] == "true")
                {
                    Sort sort = new Sort();
                    sort.start(Directory.GetCurrentDirectory());
                    Environment.Exit(0);
                }
            }

            //проверка версии сделать отключаемой, проверка файла, защита
            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo("SortFile.exe");
            WebClient webClient = new WebClient();
            webClient.DownloadFile("https://github.com/Ssid113/Sort/raw/master/StartProg/SortFile.exe", "SortFileUP.exe");
            FileVersionInfo updateFileVersionInfo = FileVersionInfo.GetVersionInfo("SortFileUP.exe");
            if (myFileVersionInfo.FileVersion != updateFileVersionInfo.FileVersion)
            {
                byte[] b = SortFile.Properties.Resources.Update;                                             //Create project Update
                FileStream fs = new FileStream("Update.exe", FileMode.Create);
                fs.Write(b, 0, b.Length);
                fs.Close();

                Process upexe = new Process();
                upexe.StartInfo.Verb = "runas";
                upexe.StartInfo.FileName = "Update.exe"; // СОЗДАТЬ ПРОВЕРКУ
                upexe.StartInfo.Arguments = "start";
                upexe.Start();
                Environment.Exit(0);
            }
            else
            {
                File.Delete("SortFileUP.exe");
            }
                  

        }
    }
}
