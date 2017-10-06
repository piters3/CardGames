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
            Deck deck = new Deck();
            _war = new War(deck.Shuffle());

            //_war.GiveOutCards();
            //_war.Name = "zxczxcxz";

            InitializeComponent();

            //ile.Text = _war.Name;
            //ile.Text = _war.MyCards.Count.ToString();
            //ile2.Text = _war.MyCards.Count.ToString();

            DataContext = _war;

            var shuffledDeck = deck.Shuffle();
            var i = 0;
            var j = 40;
            var k = 40;
            foreach (var card in shuffledDeck)
            {

                //var imageSource = new BitmapImage(new Uri("Images/"+card.Image+ ".jpg", UriKind.RelativeOrAbsolute));
                var imageSource = new BitmapImage(new Uri("Images/back.jpg", UriKind.RelativeOrAbsolute));
                var image = new Image { Source = imageSource, Margin = new Thickness(0, j, i, k) };

                Grid.SetRow(image, 1);
                Grid.SetColumn(image, 0);
                MainGrid.Children.Add(image);
                i++;
                j--;
                k++;
            }
        }


        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (MyCard.Visibility == Visibility.Visible)
            //    MyCard.Visibility = Visibility.Hidden;
            //else
            //    MyCard.Visibility = Visibility.Visible;


            //BitmapImage bi3 = new BitmapImage();
            //bi3.BeginInit();
            //bi3.UriSource = new Uri("Images\as.jpg", UriKind.Relative);
            //bi3.EndInit();
            //MyCard.Stretch = Stretch.Fill;
            //MyCard.Source = bi3;

            //ile.Text = _war.MyCards.Count.ToString();
            //_war.MyCards.Dequeue();
            //_war.Name = "asd";
            //ile2.Text = _war.MyCards.Count.ToString();
            //MyCard.Source = null;

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("Images/9Dzwonek.jpg", UriKind.RelativeOrAbsolute);
            image.EndInit();
            MyCard.Source = image;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _war.GiveOutCards();

        }
    }
}
