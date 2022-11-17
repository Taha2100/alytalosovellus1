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
using System.Windows.Threading;

namespace Älytalosovellus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Lights olohuone = new Lights();
        thermostat TalonLampo = new thermostat();
        Sauna saunaOlio = new Sauna();

        DispatcherTimer saunaPaalla = new DispatcherTimer();
        DispatcherTimer saunaPoisPaalta = new DispatcherTimer();

        DispatcherTimer saunaLampoAlas = new DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();

            lblCurrentTemp.Content = TalonLampo.Temperature.ToString();

            paivityakayttoliittymakomponentti();

            saunaPaalla.Tick += SaunanLampoYlos_Tick;
            saunaPaalla.Interval = new TimeSpan(0, 0, 1);

            saunaPoisPaalta.Tick += SaunanLampoAlas_Tick;
            saunaPoisPaalta.Interval = new TimeSpan(0, 0, 1);
        }

        private void sld_olohuonedimmer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            olohuone.Dimmer = Convert.ToInt32(sld_olohuonedimmer.Value);
            txtb_olohuonedimmer.Text = olohuone.Dimmer.ToString();

            if (olohuone.Dimmer != 0)
            {
                lbl_olohuonevalo.Content = "On";
                
            }
            else
            {
                lbl_olohuonevalo.Content = "Off";
            }
        }

        public void SaunanLampoYlos_Tick(object sender, EventArgs e)
        {
            if (saunaOlio.Lampotila <= 70)
            {
                saunaOlio.SaunanLampoYlos();
                paivityakayttoliittymakomponentti();
            }
            else
            {
                saunaPaalla.Stop();
            }


        }
        public void SaunanLampoAlas_Tick(object sender, EventArgs e)
        {
            if (saunaOlio.Lampotila > TalonLampo.Temperature)
            {
                saunaOlio.SaunanLampoAlas();
                paivityakayttoliittymakomponentti();
            }
            else
            {
                saunaPoisPaalta.Stop();

            }
        }
        private void asetaAlkuarvot()
        {
            TalonLampo.Temperature = 22;
            saunaOlio.Lampotila = TalonLampo.Temperature;
        }

        private void test()
            {
            
            }

        public void paivityakayttoliittymakomponentti()
        {
            lblCurrentTemp.Content = TalonLampo.Temperature.ToString();
            
            if (saunaOlio.Switched)
            {
                lblSaunaStatus.Content = "Saunan Lämpö Lisääntyy";
            }
            else
            {
                lblSaunaStatus.Content = "Saunan Lämpö Vähentyy";
            }
            lblSaunaLampoTila.Content = saunaOlio.Lampotila;
        }

        private void btnSetTemp_Click(object sender, RoutedEventArgs e)
        {

            TalonLampo.setTemperature(int.Parse(txtSetTemp.Text));
            paivityakayttoliittymakomponentti();
        }   //oho mun koodissa on noin 200 :/

        private void btnSaunaOn_Click(object sender, RoutedEventArgs e)
        {
            saunaOlio.laitaSaunaPaalle();
            saunaPaalla.Start();
            paivityakayttoliittymakomponentti();


        }

        private void btnSaunaOff_Click(object sender, RoutedEventArgs e)
        {
           
                saunaOlio.laitaSaunaPoisPaalta();
            saunaPaalla.Stop();
            paivityakayttoliittymakomponentti();


        }
    }
}
