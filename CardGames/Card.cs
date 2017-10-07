using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CardGames
{
    public class Card
    {
        public string Color { get; set; }
        public string Figure { get; set; }
        public int ColorNumber { get; set; }
        public int FigureNumber { get; set; }
        public Uri ImageUrl { get; set; }
        public Image Img { get; set; }
    }
}
