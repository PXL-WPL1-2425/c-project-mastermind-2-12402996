using System.Diagnostics;
using System.Printing;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks.Dataflow;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.WebRequestMethods;

namespace C_mastermindSprint1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        List<string> colors = new List<string> { "Red", "Yellow", "Orange", "White", "Green", "Blue" };
        private List<string> secretCode = new List<string>();
        int guessAttempts = 0;
        DateTime startedGuessTime;
        int score = 100;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var randomCode = new Random();

            for (int i = 0; i < 4; i++)
            {
                secretCode.Add(colors[randomCode.Next(colors.Count)]);
            }

            generatedCodeTextBox.Text = $"{secretCode}".ToString();
            this.Title = $"Poging: {guessAttempts}";
            StartCountDown();
            generatedCodeTextBox.Visibility = Visibility.Collapsed;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            // Deel 1. Bereken tijdsverschil
            TimeSpan timeUsedToGuess = DateTime.Now - startedGuessTime;
            // Deel 2. controle, if time > 10 seconds
            if (timeUsedToGuess.TotalSeconds > 10)
            {
                StopCountDown();
                startedGuessTime = DateTime.Now;
            }
            timerTextBox.Text = timeUsedToGuess.TotalSeconds.ToString("N0");
        }
        /// <summary>
        /// Deze methode zorgt eerst en vooral ervoor dat de timer stopt en vervolgens de poging verhoogt. 
        /// Nadien wordt er een messagebox getoond.
        /// de titel van het venster wordt aangepast en de timer wordt opnieuw gestart.
        /// </summary>
        private void StopCountDown()
        {
            timer.Stop();
            guessAttempts++;
            MessageBox.Show("Je beurt is over, probeer opnieuw", "Je tijd is verstreken, To Slow.", MessageBoxButton.OK, MessageBoxImage.Warning);
            this.Title = $"Poging: {guessAttempts}";
            StartCountDown();
        }
        /// <summary>
        /// Start de interval van de timer en zorgt ervoor dat de timer elke 100 milliseconden telt.
        /// </summary>
        private void StartCountDown()
        {
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
            startedGuessTime = DateTime.Now;
            timer.Start();
        }


        private void ComboBoxColour_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            if (sender == comboBoxColour1 && comboBoxColour1.SelectedItem != null)
            {
                switch (comboBoxColour1.SelectedIndex)
                {
                    case 0:
                        labelColorOne.Background = new SolidColorBrush(Colors.Red);
                        break;
                    case 1:
                        labelColorOne.Background = new SolidColorBrush(Colors.Yellow);
                        break;
                    case 2:
                        labelColorOne.Background = new SolidColorBrush(Colors.Orange);
                        break;
                    case 3:
                        labelColorOne.Background = new SolidColorBrush(Colors.White);
                        break;
                    case 4:
                        labelColorOne.Background = new SolidColorBrush(Colors.Green);
                        break;
                    case 5:
                        labelColorOne.Background = new SolidColorBrush(Colors.Blue);
                        break;
                }
            }
            if (sender == comboBoxColour2 && comboBoxColour2.SelectedItem != null)
            {
                switch (comboBoxColour2.SelectedIndex)
                {
                    case 0:
                        labelColorTwo.Background = new SolidColorBrush(Colors.Red);
                        break;
                    case 1:
                        labelColorTwo.Background = new SolidColorBrush(Colors.Yellow);
                        break;
                    case 2:
                        labelColorTwo.Background = new SolidColorBrush(Colors.Orange);
                        break;
                    case 3:
                        labelColorTwo.Background = new SolidColorBrush(Colors.White);
                        break;
                    case 4:
                        labelColorTwo.Background = new SolidColorBrush(Colors.Green);
                        break;
                    case 5:
                        labelColorTwo.Background = new SolidColorBrush(Colors.Blue);
                        break;
                }
            }
            if (sender == comboBoxColour3 && comboBoxColour3.SelectedItem != null)
            {
                switch (comboBoxColour3.SelectedIndex)
                {
                    case 0:
                        labelColorThree.Background = new SolidColorBrush(Colors.Red);
                        break;
                    case 1:
                        labelColorThree.Background = new SolidColorBrush(Colors.Yellow);
                        break;
                    case 2:
                        labelColorThree.Background = new SolidColorBrush(Colors.Orange);
                        break;
                    case 3:
                        labelColorThree.Background = new SolidColorBrush(Colors.White);
                        break;
                    case 4:
                        labelColorThree.Background = new SolidColorBrush(Colors.Green);
                        break;
                    case 5:
                        labelColorThree.Background = new SolidColorBrush(Colors.Blue);
                        break;

                }
            }
            if (sender == comboBoxColour4 && comboBoxColour4.SelectedItem != null)
            {
                switch (comboBoxColour4.SelectedIndex)
                {
                    case 0:
                        labelColorFour.Background = new SolidColorBrush(Colors.Red);
                        break;
                    case 1:
                        labelColorFour.Background = new SolidColorBrush(Colors.Yellow);
                        break;
                    case 2:
                        labelColorFour.Background = new SolidColorBrush(Colors.Orange);
                        break;
                    case 3:
                        labelColorFour.Background = new SolidColorBrush(Colors.White);
                        break;
                    case 4:
                        labelColorFour.Background = new SolidColorBrush(Colors.Green);
                        break;
                    case 5:
                        labelColorFour.Background = new SolidColorBrush(Colors.Blue);
                        break;
                }

            }
        }
       
        private void checkButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxColour1.Text) ||
              string.IsNullOrEmpty(comboBoxColour2.Text) ||
              string.IsNullOrEmpty(comboBoxColour3.Text) ||
              string.IsNullOrEmpty(comboBoxColour4.Text))
            {
                MessageBox.Show("Je moet een kleur kiezen", "Input Fout", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            guessAttempts++;
            this.Title = $"Poging: " + guessAttempts;
            UpdateTitle();

            if (guessAttempts >= 10)
            {
                timer.Stop();
                MessageBox.Show($"Je hebt geen pogingen meer over. De correcte code was {string.Join(", ", secretCode)}", "Game Over", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            StartCountDown();

            string checkColor1 = comboBoxColour1.Text;
            string checkColor2 = comboBoxColour2.Text;
            string checkColor3 = comboBoxColour3.Text;
            string checkColor4 = comboBoxColour4.Text;
            List<string> inputColor = new List<string> { checkColor1, checkColor2, checkColor3, checkColor4 };

            StackPanel colorPanel = new StackPanel { Orientation = Orientation.Horizontal};
            for (int i = 0; i < inputColor.Count; i++)
            {
                Rectangle rect = new Rectangle
                {
                    Width = 190,
                    Height = 40,
                    Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(inputColor[i]))
                };

                if (secretCode[i] == inputColor[i])
                {
                    rect.Stroke = Brushes.DarkRed;
                    rect.StrokeThickness = 5;
                }
                else if (secretCode.Contains(inputColor[i]))
                {
                    rect.Stroke = Brushes.Wheat;
                    rect.StrokeThickness = 5;
                }
                else
                {
                    rect.Stroke = Brushes.Transparent;
                    rect.StrokeThickness = 5;
                }

                colorPanel.Children.Add(rect);
            }
            colorHistoryListBox.Items.Add(new ListBoxItem { Content = colorPanel });

            int penaltyPoints = CalculatePenaltyPoints(inputColor); // Berekening van strafpunten
            score -= penaltyPoints; // Aftrekken van strafpunten van de score
            labelScore.Content = $"Score: {score}"; // Bijwerken van de score

            for (int i = 0; i < 4; i++)
            {
                Label checkColors = null;

                switch (i)
                {
                    case 0:
                        checkColors = labelColorOne;
                        break;
                    case 1:
                        checkColors = labelColorTwo;
                        break;
                    case 2:
                        checkColors = labelColorThree;
                        break;
                    case 3:
                        checkColors = labelColorFour;
                        break;
                }
            }            
        }
        private int CalculatePenaltyPoints(List<string> userGuess)
        {
            int penaltyPoints = 0;

            for (int i = 0; i < userGuess.Count; i++)
            {
                if (userGuess[i] == secretCode[i])
                {
                    // Correct color and position
                    penaltyPoints += 0;
                }
                else if (secretCode.Contains(userGuess[i]))
                {
                    // Correct color but wrong position
                    penaltyPoints += 1;
                }
                else
                {
                    // Color not in the code
                    penaltyPoints += 2;
                }
            }

            return penaltyPoints;
        }
        private void UpdateTitle()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(guessAttempts);
            this.Title = sb.ToString();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.F12)
            {
                ToggleDebug();
            }
        }
        /// <summary>
        /// Hier kijkt de methode of de textbox zichtbaar is of niet.
        /// Vervolgens kan ik de textbox zichtbaar maken of verbergen met de toetsencombinatie CTRL + F12.
        /// </summary>
        private void ToggleDebug()
        {
            if (generatedCodeTextBox.Visibility == Visibility.Visible)
            {
                generatedCodeTextBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (secretCode is List<string> secretCodeList)
                {
                    generatedCodeTextBox.Text = string.Join(", ", secretCodeList);
                    generatedCodeTextBox.Visibility = Visibility.Visible;
                }
            }
        }
    }
}


     
    