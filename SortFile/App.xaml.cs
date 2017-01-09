using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Windows;


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
                if(e.Args[0] == "true")
                {
                    Sort sort = new Sort();
                    sort.start(Directory.GetCurrentDirectory());
                    Environment.Exit(0);
                }
            }

        }
    }
}
