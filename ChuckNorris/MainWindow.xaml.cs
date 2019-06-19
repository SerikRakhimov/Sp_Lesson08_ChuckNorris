using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChuckNorris
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            taskRun();
        }

        public void taskRun()
        {

            Task<string> myTask = new Task<string>(() =>
            {
                WebRequest req = WebRequest.Create(@"https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random");
                req.Headers.Add("X-RapidAPI-Host","matchilling-chuck-norris-jokes-v1.p.rapidapi.com");
                req.Headers.Add("X-RapidAPI-Key","7e8fc9de70msh112263a6a3d4175p198551jsnc5bbb0e1d0af");
                req.ContentType = "application/json";

                string jsonText = "";

                WebResponse response = req.GetResponse();

                using (Stream s = response.GetResponseStream()) //Пишем в поток.
                {
                    using (StreamReader r = new StreamReader(s)) //Читаем из потока.
                    {
                        jsonText = r.ReadToEnd();
                    }
                }
                response.Close(); //Закрываем поток
                return jsonText;
            });

            myTask.Start();
            string jsonResult = myTask.Result;

            //  var dopinfo = JObject.Parse(jsonText);
            Info info = JsonConvert.DeserializeObject<Info>(jsonResult);

            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource = new Uri(info.Icon_url, UriKind.Absolute);
            bmp.EndInit();
            imageInfo.Source = bmp;

            valueInfo.Text = info.Value;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            taskRun();

        }
    }
}
