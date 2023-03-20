using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Xml.Serialization;

namespace GitAcaunt
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        ProcessStartInfo gitInfo;
        string[] users = new string[5];
        User Us6N2P;
        User UsSergey;
        public MainWindow()
        {
            InitializeComponent();

            gitInfo = new ProcessStartInfo();
            gitInfo.CreateNoWindow = true;
            gitInfo.RedirectStandardError = true;
            gitInfo.RedirectStandardOutput = true;
            gitInfo.UseShellExecute = false;

            gitInfo.FileName = @"C:\Program Files\Git\bin\git.exe";

            users = HandlerFile.GetUsers();

            Us6N2P = new User("6N2P",users[1], users[2]);
            UsSergey = new User("sergey",users[3], users[4]);

            //Проверка для десериализации при загрузке программы
            User DeserialUser = new User();
            if (File.Exists("serialUeser.xml"))
            {
                DeserialUser = DeserializeUser();
                tb_Text.Text = $"Аккаунт {DeserialUser.Name}";
            }
            else
            {
                User6N2P();
            }
        }
        public void User6N2P()
        {
            Process gitProces = new Process();
            gitInfo.Arguments = Us6N2P.Name;            

            //  gitInfo.WorkingDirectory = YOUR_GIT_REPOSITORY_PATH;

            gitProces.StartInfo = gitInfo;            
            gitProces.Start();

            string stderr_str = gitProces.StandardError.ReadToEnd();
            string stdout_str = gitProces.StandardOutput.ReadToEnd();

            gitProces.WaitForExit();
            gitProces.Close();

            gitInfo.Arguments = Us6N2P.Maill;
            gitProces.StartInfo = gitInfo;
            gitProces.Start();

             stderr_str = gitProces.StandardError.ReadToEnd();
             stdout_str = gitProces.StandardOutput.ReadToEnd();

            gitProces.WaitForExit();
            gitProces.Close();

            SerializeUser(Us6N2P);

           // MessageBox.Show("Учетка изменена на 6N2P");           
        }
        public void UserSergey()

        {          
            Process gitProcesS = new Process();
            gitInfo.Arguments = UsSergey.Name;
            

            gitProcesS.StartInfo = gitInfo;
            gitProcesS.Start();

            string stderr_str =gitProcesS.StandardError.ReadToEnd();
            string stdout_str =gitProcesS.StandardOutput.ReadToEnd();

            gitProcesS.WaitForExit();
            gitProcesS.Close();

            gitInfo.Arguments = UsSergey.Maill;

            gitProcesS.StartInfo = gitInfo;
            gitProcesS.Start();

             stderr_str = gitProcesS.StandardError.ReadToEnd();
             stdout_str = gitProcesS.StandardOutput.ReadToEnd();

            gitProcesS.WaitForExit();
            gitProcesS.Close();

            SerializeUser(UsSergey);

          //  MessageBox.Show("Учетка изменена на sergey");
        }
        private void Button_Click_6N2P(object sender, RoutedEventArgs e)
        {
            User6N2P();
            tb_Text.Text = $"Аккаунт {Us6N2P.Name}";
        }
        private void Button_Click_Sergey(object sender, RoutedEventArgs e)
        {
            UserSergey();
            tb_Text.Text = $"Аккаунт {UsSergey.Name}";
        }
       static void SerializeUser(User user)
        {
            //Создание сеариализатор на основе класса User
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
            //Создание потока для сохронения данных
            Stream fStream = new FileStream ("serialUeser.xml", FileMode.Create, FileAccess.Write);
            //Запуск процесса сериализации
            xmlSerializer.Serialize(fStream, user);
            //Закрытие потока
            fStream.Close();
        }
        static User DeserializeUser()
        {
            User tempUser = new User();
            //Создается скриализатор на основе указанного типа
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
            //Создается поток для чтения данных
            Stream fStream = new FileStream("serialUeser.xml", FileMode.Open, FileAccess.Read);
            //Запускается процесс десериализации
            tempUser=xmlSerializer.Deserialize(fStream) as User;
            //Закрываю поток
            fStream.Close();
            //Возвращаю результат
            return tempUser;
        }
    }
}
