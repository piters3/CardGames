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

        public WarPage()
        {
            InitializeComponent();
           
            
            

            Deck deck = new Deck();
            _war = new War(deck.Shuffle());
           
            DataContext = _war;


            //var shuffledDeck = deck.Shuffle();
            //var i = 0;
            //var j = 40;
            //var k = 40;
            //foreach (var card in shuffledDeck)
            //{

            //    //var imageSource = new BitmapImage(new Uri("Images/"+card.Image+ ".jpg", UriKind.RelativeOrAbsolute));
            //    var imageSource = new BitmapImage(new Uri("Images/back.jpg", UriKind.RelativeOrAbsolute));
            //    var image = new Image { Source = imageSource, Margin = new Thickness(0, j, i, k) };

            //    Grid.SetRow(image, 1);
            //    Grid.SetColumn(image, 0);
            //    MainGrid.Children.Add(image);
            //    i++;
            //    j--;
            //    k++;
            //}

            //foreach(var item in deck.Shuffle())
            //{
            //    Console.WriteLine($"{item.Color}");
            //}


        }


        private void ThrowCard(object sender, MouseButtonEventArgs e)
        {
            _war.ThrowCard();
        }

        private void GiveOutCardsButtonClick(object sender, RoutedEventArgs e)
        {
            _war.GiveOutCards();
            var button = sender as Button;
            button.Visibility = Visibility.Hidden;
            MyCards.Visibility = Visibility.Visible;
            EnemyCards.Visibility = Visibility.Visible;
        }
    }
}
