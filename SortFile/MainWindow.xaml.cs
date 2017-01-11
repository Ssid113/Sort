using System;
using System.IO;
using System.Windows;
using System.Diagnostics;

namespace SortFile
{
    public partial class MainWindow : Window
    {
        private Sort sort = new Sort();
        public MainWindow()
        {

            InitializeComponent();
            SettingStart();

        }

        private void path_Click(object sender, RoutedEventArgs e)                               // Change directory
        {
            System.Windows.Forms.FolderBrowserDialog DirDialog = new System.Windows.Forms.FolderBrowserDialog();
            DirDialog.Description = "Выбор директории";
            DirDialog.SelectedPath = Environment.CurrentDirectory;                              // Start directory
            DirDialog.ShowDialog(); 
            pathtextBox.Text = DirDialog.SelectedPath;
        }
        private void start_Click(object sender, RoutedEventArgs e)
        {
            sort.start(pathtextBox.Text);                                                       // Start
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);                                                                // Exit
        }
        private void dateCreateButton_Checked(object sender, RoutedEventArgs e)
        {
            dateCreateButton.IsChecked = true;
            dateChangeButton.IsChecked = false;

        }
        private void dateChangeButton_Checked(object sender, RoutedEventArgs e)
        {
            dateChangeButton.IsChecked = true;
            dateCreateButton.IsChecked = false;
        }
        private void saveConfig_Click(object sender, RoutedEventArgs e)
        {
            SettingSave();
        }
        private void regButtom_Click(object sender, RoutedEventArgs e)
        {
            byte[] b = Properties.Resources.DeleteCreateSubKeyRegister;                                             //Create project DeleteCreateSubKeyRegister
            FileStream fs = new FileStream(System.Windows.Forms.Application.StartupPath + @"\DeleteCreateSubKeyRegister1.exe", FileMode.Create);
            fs.Write(b, 0, b.Length);
            fs.Close();

            Process regexe = new Process();
            regexe.StartInfo.Verb = "runas";
            regexe.StartInfo.FileName = System.Windows.Forms.Application.StartupPath + @"\DeleteCreateSubKeyRegister1.exe"; // СОЗДАТЬ ПРОВЕРКУ И ЗАЩИТУ РЕЕСТРА ОТ МУСОРА
            regexe.StartInfo.Arguments = "start " + Properties.Settings.Default.SettingNameStart + " " + Properties.Settings.Default.SettingNameSetting;
            try
            {
                regexe.Start(); 
                regexe.WaitForExit();
                MessageBox.Show(regexe.ExitCode.ToString());
                regexe.Close();
            }
            catch { }


            File.Delete(System.Windows.Forms.Application.StartupPath + @"\DeleteCreateSubKeyRegister1.exe");

        }
        private void regdelButton_Click(object sender, RoutedEventArgs e)
        {
            byte[] b = Properties.Resources.DeleteCreateSubKeyRegister;                                             //Create project DeleteCreateSubKeyRegister
            FileStream fs = new FileStream(System.Windows.Forms.Application.StartupPath + @"\DeleteCreateSubKeyRegister1.exe", FileMode.Create);
            fs.Write(b, 0, b.Length);
            fs.Close();

            Process regexe = new Process(); 
            regexe.StartInfo.Verb = "runas";
            regexe.StartInfo.FileName = System.Windows.Forms.Application.StartupPath + @"\DeleteCreateSubKeyRegister1.exe"; // СОЗДАТЬ ПРОВЕРКУ
            regexe.StartInfo.Arguments = "del ";
            try
            {
                regexe.Start(); 
                regexe.WaitForExit();
                MessageBox.Show(regexe.ExitCode.ToString());
                regexe.Close();
            }
            catch { }

            File.Delete(System.Windows.Forms.Application.StartupPath + @"\DeleteCreateSubKeyRegister1.exe");
        }

        private void YcheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.SettingDate = 0;
            Properties.Settings.Default.SettingBlock = 1;
            YcheckBox.IsChecked = true;
            McheckBox.IsChecked = false;
            WcheckBox.IsChecked = false;
            DcheckBox.IsChecked = false;
            HcheckBox.IsChecked = false;
            MincheckBox.IsChecked = false;
            ScheckBox.IsChecked = false;
            Properties.Settings.Default.SettingBlock = 0;

        }

        private void McheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.SettingBlock == 0)
            {
                Properties.Settings.Default.SettingDate = 1;
                Properties.Settings.Default.SettingBlock = 1;
                McheckBox.IsChecked = true;
                WcheckBox.IsChecked = false;
                DcheckBox.IsChecked = false;
                HcheckBox.IsChecked = false;
                MincheckBox.IsChecked = false;
                ScheckBox.IsChecked = false;
                Properties.Settings.Default.SettingBlock = 0;
            }
        }
        private void WcheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.SettingBlock == 0)
            {
                Properties.Settings.Default.SettingDate = 2;
                Properties.Settings.Default.SettingBlock = 1;
                McheckBox.IsChecked = true;
                WcheckBox.IsChecked = true;
                DcheckBox.IsChecked = false;
                HcheckBox.IsChecked = false;
                MincheckBox.IsChecked = false;
                ScheckBox.IsChecked = false;
                Properties.Settings.Default.SettingBlock = 0;
            }
        }
        private void DcheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.SettingBlock == 0)
            {
                Properties.Settings.Default.SettingDate = 3;
                Properties.Settings.Default.SettingBlock = 1;
                McheckBox.IsChecked = true;
                WcheckBox.IsChecked = true;
                DcheckBox.IsChecked = true;
                HcheckBox.IsChecked = false;
                MincheckBox.IsChecked = false;
                ScheckBox.IsChecked = false;
                Properties.Settings.Default.SettingBlock = 0;
            }
        }
        private void HcheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.SettingBlock == 0)
            {
                Properties.Settings.Default.SettingDate = 4;
                Properties.Settings.Default.SettingBlock = 1;
                McheckBox.IsChecked = true;
                WcheckBox.IsChecked = true;
                DcheckBox.IsChecked = true;
                HcheckBox.IsChecked = true;
                MincheckBox.IsChecked = false;
                ScheckBox.IsChecked = false;
                Properties.Settings.Default.SettingBlock = 0;
            }
        }
        private void MincheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.SettingBlock == 0)
            {
                Properties.Settings.Default.SettingDate = 5;
                Properties.Settings.Default.SettingBlock = 1;
                McheckBox.IsChecked = true;
                WcheckBox.IsChecked = true;
                DcheckBox.IsChecked = true;
                HcheckBox.IsChecked = true;
                MincheckBox.IsChecked = true;
                ScheckBox.IsChecked = false;
                Properties.Settings.Default.SettingBlock = 0;
            }
        }
        private void ScheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.SettingBlock == 0)
            {
                Properties.Settings.Default.SettingDate = 6;
                Properties.Settings.Default.SettingBlock = 1;
                McheckBox.IsChecked = true;
                WcheckBox.IsChecked = true;
                DcheckBox.IsChecked = true;
                HcheckBox.IsChecked = true;
                MincheckBox.IsChecked = true;
                ScheckBox.IsChecked = true;
                Properties.Settings.Default.SettingBlock = 0;
            }
        }

        private void SettingStart()
        {
            dateChangeButton.IsChecked = Properties.Settings.Default.SettingChangeButton;
            dateCreateButton.IsChecked = Properties.Settings.Default.SettingdateCreateButton;
            namedirecBox.Text = Properties.Settings.Default.SettingnamedirecBox;
            pathtextBox.Text = Directory.GetCurrentDirectory();                                 // Get current directory. Получаем дирректорию из которой запустили программу
            int NomberDateSort = Properties.Settings.Default.SettingDate;
            YcheckBox.IsChecked = true;
            switch (NomberDateSort)                                    // Sort setting. Настраиваем точность сортировки
            {
                case 1:
                    McheckBox.IsChecked = true;
                    break;
                case 2:
                    WcheckBox.IsChecked = true;
                    break;
                case 3:
                    DcheckBox.IsChecked = true;
                    break;
                case 4:
                    HcheckBox.IsChecked = true;
                    break;
                case 5:
                    MincheckBox.IsChecked = true;
                    break;
                case 6:
                    ScheckBox.IsChecked = true;
                    break;
                default:
                    YcheckBox.IsChecked = true;
                    break;

            }
        }
        private void SettingSave()          // Save
        {
            Properties.Settings.Default.SettingChangeButton = (bool)dateChangeButton.IsChecked;
            Properties.Settings.Default.SettingdateCreateButton = (bool)dateCreateButton.IsChecked;
            Properties.Settings.Default.SettingnamedirecBox = namedirecBox.Text;  // СОЗДАТЬ ПРОВЕРКУ
            Properties.Settings.Default.SettingBlock = 0;
            Properties.Settings.Default.Save();
            MessageBox.Show("Настройки сохранены");
        }
    }
}




