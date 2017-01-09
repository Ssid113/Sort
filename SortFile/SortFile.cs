using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortFile
{
    class Sort
    {
        public Sort()
        {

        }
        public void start(string arguments)
        {
            if (Properties.Settings.Default.SettingdateCreateButton == true) { sortdatecreate(arguments); }
            if (Properties.Settings.Default.SettingChangeButton == true) { sortdatechange(arguments); }

        }

        private void sortdatecreate(string arguments)
        {
            string pathdop;
            pathdop = arguments + "/" + Properties.Settings.Default.SettingnamedirecBox;
            DirectoryInfo dir = new DirectoryInfo(arguments);
            FileInfo[] files = dir.GetFiles();
            Directory.CreateDirectory(pathdop);
            FileInfo File1;
            //if(Properties.Settings.Default.SettingSec == false)
            //{
            //
            //}
            //else { }



            foreach (FileInfo file in files)
            {
                File1 = file;
                Directory.CreateDirectory(pathdop + "/" + file.CreationTime.Year.ToString() + file.CreationTime.Month.ToString() + "/");
                try
                {
                    File.Copy(file.FullName, pathdop + "/" + file.LastWriteTime.Year.ToString() + file.LastWriteTime.Month.ToString() + "/" + file.Name);
                }
                catch (IOException)
                {
                    // Console.WriteLine("Файл с таким же названием уже существует"); //РАБОТА С КОПИРОВАНИЕМ
                }
            }
        }


        private void sortdatechange(string arguments)
        {
            string pathdop;
            pathdop = arguments + "/" + Properties.Settings.Default.SettingnamedirecBox;

            DirectoryInfo dir = new DirectoryInfo(arguments);
            FileInfo[] files = dir.GetFiles();
            Directory.CreateDirectory(pathdop);
            foreach (FileInfo file in files)
            {
                Directory.CreateDirectory(pathdop + "/" + file.LastWriteTime.Year.ToString() + file.LastWriteTime.Month.ToString() + "/");
                try
                {
                    File.Copy(file.FullName, pathdop + "/" + file.LastWriteTime.Year.ToString() + file.LastWriteTime.Month.ToString() + "/" + file.Name);
                }
                catch (IOException)
                {
                    // Console.WriteLine("Файл с таким же названием уже существует"); //РАБОТА С КОПИРОВАНИЕМ
                }
            }


        }




    }
}
