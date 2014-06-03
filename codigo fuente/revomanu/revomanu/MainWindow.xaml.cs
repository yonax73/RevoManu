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
using MahApps.Metro.Controls;
using System.Speech.Recognition;
using System.Speech.Synthesis;
namespace Revomanu
{

    public partial class MainWindow : MetroWindow
    {

        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void REVOMANU_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Choices commands = new Choices();
                commands.Add(new String[] { "Play Musica.", "Stop Musica.", "Play Video.", "Stop Video.", "Led Rojo.", "Led Verde.", "Led Amarillo.", "Led Azul.", "Prender todos.", "Apagar todos." });
                GrammarBuilder gBuilder = new GrammarBuilder();
                gBuilder.Append(commands);
                Grammar grammar = new Grammar(gBuilder);

                recEngine.LoadGrammarAsync(grammar);

                recEngine.SetInputToDefaultAudioDevice();
                recEngine.SpeechRecognized += recEngine_SpeechRecognized;

                recEngine.RecognizeAsync(RecognizeMode.Multiple);

                synthesizer.SpeakAsync("Bienvenido a Revomanu !");
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se encontro un dispositivo de voz. Por favor verifique !" + ex.Message);

            }
        }


        private void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            switch (e.Result.Text)
            {

                case "Play Musica.":

                    mediaMusic.Play();

                    break;

                case "Stop Musica.":


                    mediaMusic.Stop();

                    break;

                case "Play Video.":


                    videoDuran.Play();

                    break;
                case "Stop Video.":

                    videoDuran.Stop();

                    break;

                case "Led Rojo.":

                    if (!Convert.ToBoolean(btnLedRojo.IsChecked))
                    {

                        btnLedRojo.IsChecked = true;
                    }
                    else
                    {
                        btnLedAmarillo.IsChecked = true;
                        btnLedAzul.IsChecked = true;
                        btnLedVerde.IsChecked = true;

                        btnLedRojo.IsChecked = false;



                    }

                    break;
                case "Led Amarillo.":

                    if (!Convert.ToBoolean(btnLedAmarillo.IsChecked))
                    {

                        btnLedAmarillo.IsChecked = true;
                    }
                    else
                    {


                        btnLedRojo.IsChecked = true;
                        btnLedAzul.IsChecked = true;
                        btnLedVerde.IsChecked = true;

                        btnLedAmarillo.IsChecked = false;


                    }

                    break;
                case "Led Verde.":

                    if (!Convert.ToBoolean(btnLedVerde.IsChecked))
                    {

                        btnLedVerde.IsChecked = true;
                    }
                    else
                    {

                        btnLedVerde.IsChecked = false;

                        btnLedRojo.IsChecked = true;
                        btnLedAmarillo.IsChecked = true;
                        btnLedAzul.IsChecked = true;


                    }

                    break;

                case "Led Azul.":

                    if (!Convert.ToBoolean(btnLedAzul.IsChecked))
                    {

                        btnLedAzul.IsChecked = true;
                    }
                    else
                    {

                        btnLedAzul.IsChecked = false;

                        btnLedRojo.IsChecked = true;
                        btnLedAmarillo.IsChecked = true;
                        btnLedVerde.IsChecked = true;

                    }


                    break;

                case "Prender todos.":

                    btnLedAmarillo.IsChecked = false;
                    btnLedAzul.IsChecked = false;
                    btnLedRojo.IsChecked = false;
                    btnLedVerde.IsChecked = false;

                    break;
                case "Apagar todos.":

                    btnLedAmarillo.IsChecked = true;
                    btnLedAzul.IsChecked = true;
                    btnLedRojo.IsChecked = true;
                    btnLedVerde.IsChecked = true;
                    break;



            }


        }

        private void btnPlayMusica_Click(object sender, RoutedEventArgs e)
        {
            mediaMusic.Play();
        }

        private void btnStopMusica_Click(object sender, RoutedEventArgs e)
        {
            mediaMusic.Stop();
        }

        private void btnPlayVideo_Click(object sender, RoutedEventArgs e)
        {
            videoDuran.Play();
        }

        private void btnStopVideo_Click(object sender, RoutedEventArgs e)
        {
            videoDuran.Stop();
        }
    }
}
