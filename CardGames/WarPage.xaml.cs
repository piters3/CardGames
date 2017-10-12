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

namespace CardGames
{
    /// <summary>
    /// Interaction logic for War.xaml
    /// </summary>
    public partial class WarPage : Page
    {
        private War _war;
        private Deck _deck;

        public WarPage()
        {
            InitializeComponent();
            _deck = new Deck();
            _war = new War(_deck.Shuffle());
            DataContext = _war;
        }


        private void ThrowCard(object sender, MouseButtonEventArgs e)
        {
            TakeWonCardsButton.Visibility = Visibility.Visible;
            MyCards.IsEnabled = false;
            TakeWonCardsButton.IsEnabled = true;

            _war.ThrowCard();

            if (_war.MyPile.Count == 0)
            {
                MessageBox.Show("Przegrałeś wojnę!", "Przegrana", MessageBoxButton.OK, MessageBoxImage.Information);
                AskForAnotherGame();
            }
            else if (_war.EnemyPile.Count == 0)
            {
                MessageBox.Show("Wygrałeś wojnę!", "Wygrana", MessageBoxButton.OK, MessageBoxImage.Information);
                AskForAnotherGame();
            }

        }

        private void AskForAnotherGame()
        {
            MessageBoxResult result = MessageBox.Show("Rozdać karty ponownie?", "Wojna", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    _war.ResetGame(_deck.Shuffle());
                    break;
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Cancel:
                    if (NavigationService.CanGoBack)
                    {
                        NavigationService.GoBack();
                    }
                    break;
            }
        }

        private void GiveOutCardsButtonClick(object sender, RoutedEventArgs e)
        {
            _war.GiveOutCards();
            var button = sender as Button;
            button.Visibility = Visibility.Hidden;
            MyCards.Visibility = Visibility.Visible;
            EnemyCards.Visibility = Visibility.Visible;
        }

        private void TakeWonCards(object sender, RoutedEventArgs e)
        {
            MyCards.IsEnabled = true;
            TakeWonCardsButton.IsEnabled = false;
            _war.TakeWonCards();
        }
    }
}
