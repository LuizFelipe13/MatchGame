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

namespace MatchGame;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        SetUpGame();
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

        Random random = new Random(); // Cria um novo gerador de números aleatórios

        foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>()) // Localiza cada TextBlock na grade principal e repete as declarações seguintes para cada um
        {
            int index = random.Next(animalEmoji.Count); // Escolhe um número aleatório entre 0 e o número do emoji que ficou na lista e o chama de "index"
            string nextEmoji = animalEmoji[index]; //Usa um número aleatório chamado "index" para obter um emoji aleatório na lista
            textBlock.Text = nextEmoji; // Atualiza o TextBlock com o emiji aleatório na lista
            animalEmoji.RemoveAt(index); // Remove o emoji aleatório da lista para que ele não seja escolhido novamente
        }
    }
}