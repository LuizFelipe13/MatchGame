using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace MatchGame
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int cronometro;
        int combinacoesEncontradas;

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        //private void Timer_Tick(object? sender, EventArgs e)
        //{
        //    cronometro++;
        //    timeTextBlock.Text = (cronometro / 10.0).ToString("0.0s");
        //    if (combinacoesEncontradas == 8)
        //    {
        //        timer.Stop();
        //        timeTextBlock.Text += " - Jogo concluído! Clique para reiniciar.";
        //    }
        //}

        private void Timer_Tick(object? sender, EventArgs e)
        {
            cronometro++;

            if (combinacoesEncontradas < 8)
            {
                // Atualiza apenas o cronômetro
                timeTextBlock.Inlines.Clear();
                timeTextBlock.Inlines.Add(new Run((cronometro / 10.0).ToString("0.0s"))
                {
                    FontSize = 36
                });
            }
            else
            {
                // Finalizado: mostra cronômetro + texto final
                timer.Stop();

                timeTextBlock.Inlines.Clear();

                // Parte 1: tempo final
                timeTextBlock.Inlines.Add(new Run((cronometro / 10.0).ToString("0.0s") + "  ")
                {
                    FontSize = 36,
                    FontWeight = FontWeights.Bold
                });

                // Parte 2: texto de reinício
                timeTextBlock.Inlines.Add(new Run("— Terminou! \nClique para reiniciar.")
                {
                    FontSize = 14,
                    FontWeight = FontWeights.SemiBold,
                    Foreground = Brushes.Red
                });
            }
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🐶", "🐶",
                "🐱", "🐱",
                "🦊", "🦊",
                "🐻", "🐻",
                "🐼", "🐼",
                "🐨", "🐨",
                "🐯", "🐯",
                "🦁", "🦁",
                "🐙", "🐙",
                "🦣", "🦣",
                "🐎", "🐎",
                "🐧","🐧",
                "🦆","🦆",
                "🐢","🐢",
                "🐓","🐓",
                "🦜","🦜"
            };

            Random random = new Random();

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];
                textBlock.Text = nextEmoji;
                textBlock.Visibility = Visibility.Visible;
                animalEmoji.RemoveAt(index);
            }

            cronometro = 0;
            combinacoesEncontradas = 0;
            findingMatch = false;
            lastTextBlockClicked = null;

            timeTextBlock.Inlines.Clear();

            timer.Start();
        }

       

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;

            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                combinacoesEncontradas++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }

        private void TimerTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (combinacoesEncontradas == 8) { // Isto define o jogo se os oito pares combinados foram encontrados (do contrário, não faz nada porque o jogo ainda continua).
                SetUpGame();
                
            }
        }
    }
}
