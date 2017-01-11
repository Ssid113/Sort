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
            File.Delete(System.Windows.Forms.Application.StartupPath + @"\Update.exe");

            //MessageBox.Show(Directory.GetCurrentDirectory());
            //MessageBox.Show(System.Reflection.Assembly.GetExecutingAssembly().Location);   //Помнить разницу
            //MessageBox.Show(System.Windows.Forms.Application.StartupPath);
            
            if (e.Args.Length !=0)
            {
                if (e.Args[0] == "afterup")
                {
                    File.Delete(System.Windows.Forms.Application.StartupPath + @"\Update.exe");
                }
                if (e.Args[0] == "true")
                {
                    Sort sort = new Sort();
                    sort.start(Directory.GetCurrentDirectory()); //нужно помнить
                    Environment.Exit(0);
                }
            }

            //проверка версии сделать отключаемой, проверка файла, защита
            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(System.Windows.Forms.Application.StartupPath + @"\SortFile.exe");
            WebClient webClient = new WebClient();
            webClient.DownloadFile("https://github.com/Ssid113/Sort/raw/master/StartProg/SortFile.exe", System.Windows.Forms.Application.StartupPath + @"\SortFileUP.exe");
            FileVersionInfo updateFileVersionInfo = FileVersionInfo.GetVersionInfo(System.Windows.Forms.Application.StartupPath + @"\SortFileUP.exe");
            if (myFileVersionInfo.FileVersion != updateFileVersionInfo.FileVersion)
            {
                byte[] b = SortFile.Properties.Resources.Update;                                             //Create project Update
                FileStream fs = new FileStream(System.Windows.Forms.Application.StartupPath + @"\Update.exe", FileMode.Create);
                fs.Write(b, 0, b.Length);
                fs.Close();

                Process upexe = new Process();
                upexe.StartInfo.Verb = "runas";
                upexe.StartInfo.FileName = System.Windows.Forms.Application.StartupPath + @"\Update.exe"; // СОЗДАТЬ ПРОВЕРКУ
                upexe.StartInfo.Arguments = "start";
                try
                {
                    upexe.Start();
                    Environment.Exit(0);
                }
                catch
                {
                    File.Delete(System.Windows.Forms.Application.StartupPath + @"\Update.exe");
                    File.Delete(System.Windows.Forms.Application.StartupPath + @"\SortFileUP.exe");
                }//проверка          
            }
            else
            {
                File.Delete(System.Windows.Forms.Application.StartupPath + @"\SortFileUP.exe");
            }


        }
    }
}
