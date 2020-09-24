using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace WPF_Buttons
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int countGames = 0;
        int totalPoints = 0;

        public MainWindow()
        {
            InitializeComponent();
         
            SoundPlayer player = new SoundPlayer(@"C:\Users\Justinas\Desktop\C# roundTwo\19. GUI BUTTONS AND DICTIONARY\WPF_Buttons\WPF_Buttons\mac420.wav");
            player.Play();
        }

        private void MestiMoneta_Click(object sender, RoutedEventArgs e)
        {
            string[] coin = { "TAILS", "HEADS" };
            Random random = new Random();
            SkaiciusArHerbas.Text = coin[random.Next(0, 2)];
            MestiMoneta.IsEnabled = false;
        }

        private void RidentiKauliuka_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            KauliukoSkaiciai.Text = random.Next(1, 7).ToString();
            RidentiKauliuka.IsEnabled = false;
            CountPoints.IsEnabled = true;
        }

        private void TotalPoints_Click(object sender, RoutedEventArgs e)
        {
            CountPoints.IsEnabled = false;

            var monetaSkaicius = Convert.ToInt32(KauliukoSkaiciai.Text) * 2;
            var monetaHerbas = Convert.ToInt32(KauliukoSkaiciai.Text);

            if ((countGames < Convert.ToInt32(NumOfGames.Text)))
            {
                countGames++;
                MestiMoneta.IsEnabled = true;
                RidentiKauliuka.IsEnabled = true;

                if (SkaiciusArHerbas.Text == "HEADS")
                {
                    totalPoints += monetaSkaicius;
                    TotalPoints.Text = $"{totalPoints}";
                }
                else
                {
                    totalPoints += monetaHerbas;
                    TotalPoints.Text = $"{totalPoints}";
                }
            }
            if (countGames == Convert.ToInt32(NumOfGames.Text))
            {
                MestiMoneta.IsEnabled = false;
                RidentiKauliuka.IsEnabled = false;

                if (Convert.ToInt32(NumOfPointsMin.Text) <= Convert.ToInt32(TotalPoints.Text) && Convert.ToInt32(NumOfPointsMax.Text) >= Convert.ToInt32(TotalPoints.Text))
                {
                    Winner.Visibility = Visibility.Visible;
                    SystemSounds.Asterisk.Play();
                }
                else
                {
                    Loser.Visibility = Visibility.Visible;
                    SystemSounds.Hand.Play();
                }
            }
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            Winner.Visibility = Visibility.Hidden;
            Loser.Visibility = Visibility.Hidden;

            countGames = 0;
            totalPoints = 0;

            NumOfGames.Clear();
            NumOfPointsMin.Clear();
            NumOfPointsMax.Clear();
            
            NumOfGames.IsEnabled = true;
            NumOfPointsMin.IsEnabled = true;
            NumOfPointsMax.IsEnabled = true;

            MestiMoneta.IsEnabled = false;
            RidentiKauliuka.IsEnabled = false;
            CountPoints.IsEnabled = false;

            SkaiciusArHerbas.Text = null;
            KauliukoSkaiciai.Text = null;
            TotalPoints.Text = null;
        }
        
        private void NumOfGames_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(NumOfGames.Text, out _) && int.TryParse(NumOfPointsMin.Text, out int num) && int.TryParse(NumOfPointsMax.Text, out int num2))
            {
                StartButton.IsEnabled = false;
            }
            else
            {
                StartButton.IsEnabled = false;
            }
        }
        
        private void NumOfPoints_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(NumOfGames.Text, out _) && int.TryParse(NumOfPointsMin.Text, out int num) && int.TryParse(NumOfPointsMax.Text, out int num2))
            {
                if ((Convert.ToInt32(NumOfPointsMin.Text) > Convert.ToInt32(NumOfPointsMax.Text)))
                {
                    StartButton.IsEnabled = false;
                }
            }
            else
            {
                StartButton.IsEnabled = false;
            }
        }

        private void NumOfPointsMax_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(NumOfGames.Text, out _) && int.TryParse(NumOfPointsMax.Text, out int num))
            {
                if (Convert.ToInt32(NumOfPointsMin.Text) < Convert.ToInt32(NumOfPointsMax.Text) && (Convert.ToInt32(NumOfPointsMin.Text) + 3) > Convert.ToInt32(NumOfPointsMax.Text))
                {
                    StartButton.IsEnabled = true;
                }
                else
                {
                    StartButton.IsEnabled = false;
                } 
            }
            else 
            {
                StartButton.IsEnabled = false;
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            NumOfGames.IsEnabled = false;
            NumOfPointsMin.IsEnabled = false;
            NumOfPointsMax.IsEnabled = false;
            StartButton.IsEnabled = false;

            MestiMoneta.IsEnabled = true;
            RidentiKauliuka.IsEnabled = true;
        }
    }
}
