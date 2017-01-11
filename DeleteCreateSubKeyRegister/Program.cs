using System;
using System.IO;
using Microsoft.Win32;

namespace DeleteCreateSubKeyRegister
{
    class Program
    {
        static int Main(string[] args)
        {
            int answer; //0 - ничего не произошло, 1 - изменилось контекстное меню, 2 - изменились данные запуска, 3 - изменились контекстное меню и запуск,
                        //4 - изменелись настройки, 5 - изменились контекстное меню и настройки, 6 - изменились данные запуска и настроек, 7 - изменилось все.
                        //0 - nothing, 1 - changed the context menu, 2 - changed run, 3 - changed context menu and run, 4 - changed setting, 
                        //5 - changed context menu and setting, 6 - changed run and setting, 7 - changed all
            if (args.Length > 0) //args[0] - system flag, args[1], args[2] - name start program and name setting program for change language
            {
                switch (args[0])
                {
                    case "del":
                        DeleteSubKeyRegister(out answer);
                        // ...
                        break;
                    default:
                        CreateSubKeyRegister(args[1], args[2], out answer);
                        // ...
                        break;
                }
            }
            else { answer = 0; }
            return answer;
        }


        private static void CreateSubKeyRegister(string NameStart,string NameSetting, out int answer)        //create keys in the registry     //создание ключей в регистре
        {
            answer = 0;
            using (RegistryKey keyContextMenu = Registry.ClassesRoot.OpenSubKey("Directory").OpenSubKey("background").OpenSubKey("shell", true),
                  keyFunction = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Microsoft",true).OpenSubKey("Windows").
                  OpenSubKey("CurrentVersion").OpenSubKey("Explorer").OpenSubKey("CommandStore").OpenSubKey("shell", true))                     //opening edit   //открытие на редактирование 
            {
                var name = ""; 
                foreach (var subKeyNames in keyContextMenu.GetSubKeyNames())
                {
                    if (subKeyNames == "ProgFileSort") { name = "ProgFileSort"; }
                }
                if (name != "ProgFileSort")
                {
                    keyContextMenu.CreateSubKey("ProgFileSort");
                    keyContextMenu.OpenSubKey("ProgFileSort", true).SetValue("MUIVerb", "ProgFileSort");
                    keyContextMenu.OpenSubKey("ProgFileSort", true).SetValue("Position", "Top");
                    keyContextMenu.OpenSubKey("ProgFileSort", true).SetValue("SubCommands", "ssid.sort(ProgFileSort);ssid.sort.settings(ProgFileSort);");

                    answer += 1; 

                }

                name = "";
                foreach (var subKeyNames in keyFunction.GetSubKeyNames())
                {
                    if (subKeyNames == "ssid.sort(ProgFileSort)") { name = "ssid.sort(ProgFileSort)"; }
                }
                if (name != "ssid.sort(ProgFileSort)")
                {
                    keyFunction.CreateSubKey("ssid.sort(ProgFileSort)");
                    keyFunction.OpenSubKey("ssid.sort(ProgFileSort)", true).SetValue("", NameStart);
                    keyFunction.OpenSubKey("ssid.sort(ProgFileSort)", true).CreateSubKey("command");
                    keyFunction.OpenSubKey("ssid.sort(ProgFileSort)", true).OpenSubKey("command", true).SetValue("", @"""" + System.Windows.Forms.Application.StartupPath + @"\SortFile.exe"" true");
                    answer += 2;
                }

                name = "";
                foreach (var KeyNames in keyFunction.GetSubKeyNames())
                {
                    if (KeyNames == "ssid.sort.settings(ProgFileSort)") { name = "ssid.sort.settings(ProgFileSort)"; }
                }
                if (name != "ssid.sort.settings(ProgFileSort)")
                {
                    keyFunction.CreateSubKey("ssid.sort.settings(ProgFileSort)");
                    keyFunction.OpenSubKey("ssid.sort.settings(ProgFileSort)", true).SetValue("", NameSetting);
                    keyFunction.OpenSubKey("ssid.sort.settings(ProgFileSort)", true).CreateSubKey("command");
                    keyFunction.OpenSubKey("ssid.sort.settings(ProgFileSort)", true).OpenSubKey("command", true).SetValue("", @"""" + System.Windows.Forms.Application.StartupPath + @"\SortFile.exe""");
                    answer += 4;
                }
            }
        }

        private static void DeleteSubKeyRegister(out int answer)      //delete keys in the registry     //удаление ключей в регистре
        {
            answer = 0;
            using (RegistryKey keyContextMenu = Registry.ClassesRoot.OpenSubKey("Directory").OpenSubKey("background").OpenSubKey("shell", true),
                  keyFunction = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Microsoft", true).OpenSubKey("Windows").
                  OpenSubKey("CurrentVersion").OpenSubKey("Explorer").OpenSubKey("CommandStore").OpenSubKey("shell", true))         //opening edit   //открытие на редактирование 
            {
                var name = "";
                foreach (var subKeyNames in keyContextMenu.GetSubKeyNames())
                {
                    if (subKeyNames == "ProgFileSort") { name = "ProgFileSort"; }
                }
                if (name == "ProgFileSort")
                {
                    keyContextMenu.DeleteSubKeyTree("ProgFileSort");
                    answer += 1; 

                }

                name = "";
                foreach (var subKeyNames in keyFunction.GetSubKeyNames())
                {
                    if (subKeyNames == "ssid.sort(ProgFileSort)") { name = "ssid.sort(ProgFileSort)"; }
                }
                if (name == "ssid.sort(ProgFileSort)")
                {
                    keyFunction.DeleteSubKeyTree("ssid.sort(ProgFileSort)");
                    answer += 2;  
                }

                name = "";
                foreach (var subKeyNames in keyFunction.GetSubKeyNames())
                {
                    if (subKeyNames == "ssid.sort.settings(ProgFileSort)") { name = "ssid.sort.settings(ProgFileSort)"; }
                }
                if (name == "ssid.sort.settings(ProgFileSort)")
                {
                    keyFunction.DeleteSubKeyTree("ssid.sort.settings(ProgFileSort)");
                    answer += 4;   
                }
            }
        }

    }
}
