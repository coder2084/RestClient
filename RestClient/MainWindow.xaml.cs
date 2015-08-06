using System;
using System.Collections.Generic;
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
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WpfApplication1.Requests;
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ctrlResponse.Text = "";          
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String authURL = @"https://utas.gt.fut.ea.com:443/ut/auth";

            using (HttpClient client = new HttpClient())            
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Request req = new AuthRequest(ctrlName.Text, ctrlPass.Password,"FFA16PCC");
                HttpResponseMessage response = await client.PostAsync(authURL, new StringContent(req.Body, Encoding.UTF8, "application/json"));
                ctrlResponse.Text = format_json(response.Content.ReadAsStringAsync().Result);

                if (response.IsSuccessStatusCode)
                {
                    HideLoginControls();
                }
   
            }                       
        }

        private string format_json(string json)
        {
            try
            {
                dynamic parsedJson = JsonConvert.DeserializeObject(json);
                return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            }catch(Exception e)
            {
                return json;
            }
        }

        private void HideLoginControls()
        {
            ctrlLoginInfo.Visibility = Visibility.Hidden;
        }

        private void ctrlPass_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {                
                e.Handled = true;
                Button_Click_1(sender, e);
            }
        }
    }
}
