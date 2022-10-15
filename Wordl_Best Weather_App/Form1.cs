using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft;
using System.Windows.Forms;

namespace Wordl_Best_Weather_App{
    public partial class Form1 : Form{
        string AppId = "";
        public Form1(){
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e){
            try{
                getWeather();
            }
            catch{
            }
        }

        void getWeather(){
            using (WebClient web = new WebClient()){
                if (this.search_city_textBox1.Text == ""){
                    return;
                }
                string url = String.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&mode=json&units=metric", this.search_city_textBox1.Text, AppId);
                var json = web.DownloadString(url);
                WeatherInfo.root info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);
                this.max_temp_value_label.Text = info.main.temp_max.ToString() + "°C";
                this.temp_value_label1.Text = info.main.temp.ToString() + "°C";
                this.min_temp_Value_label.Text = info.main.temp_min.ToString() + " °C";
                this.weather_main_label1.Text = info.weather[0].main.ToString();
                this.wind_speed_today_label21.Text = info.wind.speed.ToString() + " m/s";
                this.all_clouds_today_label.Text = info.clouds.all.ToString() + " %";
                this.weather_image_pictureBox1.ImageLocation = "http://openweathermap.org/img/w/" + info.weather[0].icon + ".png";
            }
        }
        void getForecast(){
            using (WebClient web = new WebClient()){
                string url = string.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&appid={1}&mode=json&units=metric", this.search_city_textBox1.Text, AppId);
                var json = web.DownloadString(url);
                WeatherFuture.root infofore = JsonConvert.DeserializeObject<WeatherFuture.root>(json);
                this.for1_max_label7.Text = infofore.list[0].main.temp_max.ToString();
                load_forecast(this.for1_max_label7,
                this.fore1_min_label7,0,this.day_1_pictureBox1,
                this.all_clouds_label1,this.forecast1_main_label,
                this.wind_speed_label1);
                load_forecast(this.for_2_max_temp_label4,
                this.for2_min_label7, 8, this.day_2_pictureBox1,
                this.all_clouds_label2, this.forecast2_main_label, 
                this.wind_speed_label2);
                load_forecast(this.for3_max_label11, this.for3_min_label7, 16, this.day_3_pictureBox1, this.all_clouds_label3, this.forecast3_main_label, this.wind_speed_label3);
                load_forecast(this.for4_max_label7, this.for4_min_label, 24, this.day_4_pictureBox1, this.all_clouds_label4, this.forecast4_main_label, this.wind_speed_label4);
                load_forecast(this.for5_max_label, this.for5_min_label, 32, this.day_5_pictureBox1, this.all_clouds_label5, this.forecast5_main_label, this.wind_speed_label5);
            }
        }
        void load_forecast(Label Lmax, Label lmin, int index, PictureBox pic, Label l, Label mainWeather, Label windSpeed){
            using (WebClient web = new WebClient()){
                string url = string.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&appid={1}&mode=json&units=metric",
                this.search_city_textBox1.Text, AppId);
                var json = web.DownloadString(url);
                WeatherFuture.root infofore = JsonConvert.DeserializeObject<WeatherFuture.root>(json);
                pic.ImageLocation = "http://openweathermap.org/img/w/" + infofore.list[index].weather[0].icon + ".png";
                Lmax.Text = infofore.list[index].main.temp_max.ToString() + " °C";
                lmin.Text = infofore.list[index].main.temp_min.ToString() + " °C";
                l.Text = infofore.list[index].clouds.all.ToString() + " %";
                mainWeather.Text = infofore.list[index].weather[0].main.ToString();
                windSpeed.Text = infofore.list[index].wind.speed.ToString() + " m/s";
            }
        }
        private void exit_button1_Click(object sender, EventArgs e){
            var s = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (s == DialogResult.Yes) Application.Exit();
        }

        private void city_label1_Click(object sender, EventArgs e){
        }

        private void maximize_button1_Click(object sender, EventArgs e){
            this.WindowState = FormWindowState.Minimized;
        }
        private void search_button1_Click(object sender, EventArgs e){
            try{
                getWeather();
                getForecast();
            }
            catch{
            }
        }
    }
}

      