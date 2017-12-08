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

namespace Alytalo_Uusi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Lights Keittio = new Lights();
        public Lights OloHuone = new Lights();

        public Sauna OmaSauna = new Sauna();

        public Thermostat TalonLampo = new Thermostat();
        public char AsteMerkki;
        public System.Windows.Threading.DispatcherTimer SaunaTimer = new System.Windows.Threading.DispatcherTimer();
        private object lblLampotila;

        public string A { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            Keittio.Dimmer = "0";
            Keittio.Switched = false;

            OloHuone.Dimmer = "0";
            OloHuone.Switched = false;
            OnOffVasen_txt.Text = "Off";

            OmaSauna.AsetaSauna(0);
            SaunanAsetus_textBox.Text = "";

            AsteMerkki = Convert.ToChar(176);
            UusLamoptila_textBox.Text = "21" + AsteMerkki;
            TalonLampotilaNaytto_textBox.Text = "";

          
            SaunaTimer.Tick += SaunanLampo_Tick;
            SaunaTimer.Interval = new TimeSpan(0, 0, 1);
        }

        private void SaunanLampo_Tick(object sender, EventArgs e)
        {
            OmaSauna.SaunaTemperature = OmaSauna.SaunaTemperature + 0.32;
            SaunanAsetus_textBox.Text = OmaSauna.SaunaTemperature.ToString() + A;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void OlohuoneSammutabtn_Click(object sender, RoutedEventArgs e)
        {
            OloHuone.Switched = false;
            OloHuone.Dimmer = "Off";
            OnOffVasen_txt.Text = OloHuone.Dimmer;
        }

        private void OlohuoneHimmennäbtn_Click(object sender, RoutedEventArgs e)
        {
            OloHuone.Switched = true;
            OloHuone.Dimmer = "33";
            OnOffVasen_txt.Text = OloHuone.Dimmer + "%";
        }

        private void OlohuonePuolivalotbtn_Click(object sender, RoutedEventArgs e)
        {
            OloHuone.Switched = true;
            OloHuone.Dimmer = "66";
            OnOffVasen_txt.Text = OloHuone.Dimmer + "%";
        }

        private void OlohuoneKirkasbtn_Click(object sender, RoutedEventArgs e)
        {
            OloHuone.Switched = true;
            OloHuone.Dimmer = "100";
            OnOffVasen_txt.Text = OloHuone.Dimmer + "%";
        }

        private void OnOffOikea_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void KeittioSammutabtn_Click(object sender, RoutedEventArgs e)
        {
            Keittio.SwitchOff();
            OnOffOikea_txt.Text = Keittio.Dimmer;
        }

        private void HimmennnaKeittiobtn_Click(object sender, RoutedEventArgs e)
        {
            Keittio.SwitchOn(33);
            OnOffOikea_txt.Text = Keittio.Dimmer + "%";
        }

        private void KeittioPuolivalobtn_Click(object sender, RoutedEventArgs e)
        {
            Keittio.SwitchOn(66);
            OnOffOikea_txt.Text = Keittio.Dimmer + "%";
        }

        private void Keittiokirkasbtn_Click(object sender, RoutedEventArgs e)
        {
            Keittio.SwitchOn(100);
            OnOffOikea_txt.Text = Keittio.Dimmer + "%";
        }

        private void AsetaLampotila_btn_Click(object sender, RoutedEventArgs e)
        { 
            int UusiLampotila;
            try
            {
                UusiLampotila = Int32.Parse(UusLamoptila_textBox.Text);

                if ((UusiLampotila >= 15) && (UusiLampotila < 40))
                {

                    TalonLampo.LampotilanAsetus(UusiLampotila);
                    TalonLampotilaNaytto_textBox.Text = TalonLampo.Temperature.ToString() + AsteMerkki;
                    UusLamoptila_textBox.Text = "";
                }

                else
                {
                    MessageBox.Show("Lämpötilan tulee olla välillä 15..39 astetta");
                }
            }
            catch
            {
                MessageBox.Show("Lämpötilan asettaminen epäonnistui! Vinkki: käytä numeroarvoa ;)");
            }
        }
        private void SaunanAsetusbtn_Click(object sender, RoutedEventArgs e)
        {
            if (OmaSauna.Switched)
            {

                OmaSauna.AsetaSauna(0);
                SaunanAsetus_textBox.Text = "";
                SaunaTimer.Stop();
                SaunanAsetus_textBox.Text = "";
            }

            else

            {
                OmaSauna.AsetaSauna(1);
                SaunanAsetus_textBox.Text = "SAUNA PÄÄLLÄ";
                SaunaTimer.Start();
            }
         }

       
        }
    }

