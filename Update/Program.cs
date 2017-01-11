using System;
using System.IO;
using System.Diagnostics;

namespace Update
{
    class Program   //Yes, it is my golden hammer...
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                //Готовка
                File.Delete("SortFile.exe");
                File.Move("SortFileUP.exe", "SortFile.exe");
                Process startexe = new Process();
                startexe.StartInfo.FileName = "SortFile.exe"; // СОЗДАТЬ ПРОВЕРКУ
                startexe.StartInfo.Arguments = "afterup"; //не работает как надо...
                startexe.Start();
                Environment.Exit(0);
            }
        }
    }
}
