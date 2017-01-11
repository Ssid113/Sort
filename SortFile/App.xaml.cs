﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
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

            //проверка версии сделать отключаемой
            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(@"SortFile.exe");
            FileVersionInfo updateFileVersionInfo = FileVersionInfo.GetVersionInfo(@"C:\Users\Шашеро\Documents\Visual Studio 2015\Projects\DateFile\Sort\StartProg\SortFile.exe");
            if (myFileVersionInfo.FileVersion != updateFileVersionInfo.FileVersion)
            {
                byte[] b = SortFile.Properties.Resources.Update;                                             //Create project Update
                FileStream fs = new FileStream("Update.exe", FileMode.Create);
                fs.Write(b, 0, b.Length);
                fs.Close();

                Process regexe = new Process();
                regexe.StartInfo.Verb = "runas";
                regexe.StartInfo.FileName = "Update.exe"; // СОЗДАТЬ ПРОВЕРКУ
                regexe.StartInfo.Arguments = "start";
                regexe.Start();
                Environment.Exit(0);
            }

        }
    }
}
