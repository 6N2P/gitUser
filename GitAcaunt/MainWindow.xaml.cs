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

        public MainWindow()
        {
            InitializeComponent();
        }

        public void User6N2P()
        {           
            ProcessStartInfo gitInfo = new ProcessStartInfo();
            gitInfo.CreateNoWindow = true;
            gitInfo.RedirectStandardError = true;
            gitInfo.RedirectStandardOutput = true;
            gitInfo.UseShellExecute = false;

            gitInfo.FileName = @"C:\Program Files\Git\bin\git.exe";

            Process gitProces = new Process();
            gitInfo.Arguments = "config --global user.name '6N2P'";
            gitInfo.Arguments = "config --global user.email 'umnik1985@mail.ru'";

            //  gitInfo.WorkingDirectory = YOUR_GIT_REPOSITORY_PATH;

            gitProces.StartInfo = gitInfo;            
            gitProces.Start();
           

            string stderr_str = gitProces.StandardError.ReadToEnd();
            string stdout_str = gitProces.StandardOutput.ReadToEnd();

            gitProces.WaitForExit();
            gitProces.Close();
           
        }

        public void UserSergey()

        {
            ProcessStartInfo gitInfo = new ProcessStartInfo();
            gitInfo.CreateNoWindow = true;
            gitInfo.RedirectStandardError = true;
            gitInfo.RedirectStandardOutput = true;
            gitInfo.UseShellExecute = false;

            gitInfo.FileName = @"C:\Program Files\Git\bin\git.exe";

            Process gitProces = new Process();
            gitInfo.Arguments = "config --global user.name 'sergey'";
            gitInfo.Arguments = "config --global user.email 'ivanovsv@tmnkonst.ru";

            gitProces.StartInfo = gitInfo;
            gitProces.Start();

            string stderr_str =gitProces.StandardError.ReadToEnd();
            string stdout_str =gitProces.StandardOutput.ReadToEnd();

            gitProces.WaitForExit();
            gitProces.Start();
        }

        private void Button_Click_6N2P(object sender, RoutedEventArgs e)
        {
            User6N2P();
        }

       

        private void Button_Click_Sergey(object sender, RoutedEventArgs e)
        {
            UserSergey();
        }
       
    }
}
