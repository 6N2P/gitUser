using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace GitAcaunt
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProcessStartInfo gitInfo;
        string[] users = new string[5];
        public MainWindow()
        {
            InitializeComponent();

            gitInfo = new ProcessStartInfo();
            gitInfo.CreateNoWindow = true;
            gitInfo.RedirectStandardError = true;
            gitInfo.RedirectStandardOutput = true;
            gitInfo.UseShellExecute = false;

            gitInfo.FileName = @"C:\Program Files\Git\bin\git.exe";

            users= HandlerFile.GetUsers();


        }

        public void User6N2P()
        {
            

            Process gitProces = new Process();
            gitInfo.Arguments = users[1];
            

            //  gitInfo.WorkingDirectory = YOUR_GIT_REPOSITORY_PATH;

            gitProces.StartInfo = gitInfo;            
            gitProces.Start();

            string stderr_str = gitProces.StandardError.ReadToEnd();
            string stdout_str = gitProces.StandardOutput.ReadToEnd();

            gitProces.WaitForExit();
            gitProces.Close();

            gitInfo.Arguments = users[2];
            gitProces.StartInfo = gitInfo;
            gitProces.Start();


             stderr_str = gitProces.StandardError.ReadToEnd();
             stdout_str = gitProces.StandardOutput.ReadToEnd();

            gitProces.WaitForExit();
            gitProces.Close();

            MessageBox.Show("Учетка изменена на 6N2P");
           
        }

        public void UserSergey()

        {          

            Process gitProcesS = new Process();
            gitInfo.Arguments = users[3];
            

            gitProcesS.StartInfo = gitInfo;
            gitProcesS.Start();

            string stderr_str =gitProcesS.StandardError.ReadToEnd();
            string stdout_str =gitProcesS.StandardOutput.ReadToEnd();

            gitProcesS.WaitForExit();
            gitProcesS.Close();

            gitInfo.Arguments = users[4];

            gitProcesS.StartInfo = gitInfo;
            gitProcesS.Start();

             stderr_str = gitProcesS.StandardError.ReadToEnd();
             stdout_str = gitProcesS.StandardOutput.ReadToEnd();

            gitProcesS.WaitForExit();
            gitProcesS.Close();

            MessageBox.Show("Учетка изменена на sergey");
        }

        private void Button_Click_6N2P(object sender, RoutedEventArgs e)
        {
            User6N2P();
            tb_Text.Text = "Аккаунт 6N2P";
        }

       

        private void Button_Click_Sergey(object sender, RoutedEventArgs e)
        {
            UserSergey();
            tb_Text.Text = "Аккаунт sergey";
        }
       
    }
}
