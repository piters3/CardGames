using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CardGames
{
    public class Deck
    {
        private string[] _colors;
        private string[] _figures;
        public ObservableCollection<Card> _deck = new ObservableCollection<Card>();

        public Deck()
        {
            _colors = new string[] { "Wino", "Żołądź", "Dzwonek", "Serce" };
            _figures = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Walet", "Dama", "Król", "As" };
            //_colors = new string[] { "Wino" };
            //_figures = new string[] { "2", "3" };
            _deck = new ObservableCollection<Card>();
            CreateDeck();
        }

        public void CreateDeck()
        {
            for (int i = 0; i < _colors.Length; i++)
            {
                for (int j = 0; j < _figures.Length; j++)
                {
                    _deck.Add(new Card
                    {
                        ColorNumber = i,
                        FigureNumber = j + 2,
                        Color = _colors[i],
                        Figure = _figures[j],
                        ImageUrl = new Uri("Images/" + _figures[j] + _colors[i] + ".jpg", UriKind.Relative),
                        Img = CreateImg(new Uri("Images/" + _figures[j] + _colors[i] + ".jpg", UriKind.Relative))
                    });

                }
            }

            var Joker = new Card
            {
                FigureNumber = 15,
                Figure = "Joker",
                ImageUrl = new Uri("Images/Joker.jpg", UriKind.Relative),
                Img = CreateImg(new Uri("Images/Joker.jpg", UriKind.Relative))
            };

            _deck.Add(Joker);
            _deck.Add(Joker);
        }


        private Image CreateImg(Uri url)
        {
            BitmapImage source = new BitmapImage();
            source.BeginInit();
            source.UriSource = url;
            source.EndInit();

            var img = new Image
            {
                Source = source
            };
            return img;
        }
        
        public ObservableCollection<Card> Shuffle()
        {
            var rnd = new Random();
            var result = _deck.OrderBy(item => rnd.Next()).ToList();
            return new ObservableCollection<Card>(result);
        }
    }
}

