using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Emit;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json;
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
using Microsoft.VisualBasic;
using System.Threading;
using Microsoft.Win32;

namespace WpfAppWther
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ModelV model = new ModelV();       
        public MainWindow()
        {
            InitializeComponent();
            TextBoxC.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
            if (File.Exists("WeatherTemp.json"))
            {
                model.LoadFile("WeatherTemp.json");
                labelprint();
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (TextBoxC.Text != "")
            {
                Button.IsEnabled = false;
                try
                {
                    model.ResponseMessage(TextBoxC.Text);
                }
                catch (InvalidOperationException ex)
                {
                    LabelEx.Content = ex.Message;
                }
                catch (HttpRequestException ex)
                {
                    LabelEx.Content = ex.Message;
                }
                catch (TaskCanceledException ex)
                {
                    LabelEx.Content = ex.Message;
                }
                catch (JsonException ex) 
                {
                    LabelEx.Content = ex.Message;
                }
                await Task.Delay(3000);
                labelprint();
                model.SaveFile("WeatherTemp.json");
                model.SaveFile($"SaveData\\{System.DateTime.Now.ToShortDateString()}_{model.ReturnCityNameOpenWeather()}.json");
                Button.IsEnabled = true;
            }
        }
        private void labelprint()
        {
            LabelOpenWeat.Content = $"OpenWeath\n{model.ReturnCityNameOpenWeather()}\n{Math.Round(Convert.ToDouble(model.ReturnTempOpenWeather()),2)}  C";
            LabelWeatherApi.Content = $"WeatherApi\n{model.ReturnCityNameWeatherApi()}\n{Math.Round(Convert.ToDouble(model.ReturnTempWeatherApi()),2)}  C";
            LabelVisualCros.Content = $"VisualCross\n{model.ReturnCityNameVissCross()}\n{Math.Round(Convert.ToDouble(model.ReturnTempVissCrossWeather()),2)}  C";
            LabelWeatherStack.Content = $"WeatherStack\n{model.ReturnCityNameWeatherStack()}\n{Math.Round(Convert.ToDouble(model.ReturnTempWeatherStack()),2)}  C";
            AverageTemp.Content = $"Средняя температура\n{Math.Round(model.ReturnAverageTemp(),2)}  C";
        }

        void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button.IsEnabled= false;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"SaveData\";
            openFileDialog.Filter = "json files (*.json)|*.json";
            if (openFileDialog.ShowDialog() == true)
            {
                model.LoadFile(openFileDialog.FileName);
            }
            labelprint();
            Button.IsEnabled= true;
        }
    }
}
