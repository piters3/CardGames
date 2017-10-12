using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace CardGames
{
    public class War : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private ObservableCollection<Card> _deck;
        private ObservableCollection<Card> _myPile;
        private ObservableCollection<Card> _enemyPile;
        private Card _enemyThrownCard;
        private Card _myThrownCard;
        private string _status;
        private Card _myFirstTakencard;
        private Card _mySecondTakenCard;
        private Card _enemyFirstTakenCard;
        private Card _enemySecondTakenCard;


        public Card EnemyFirstTakenCard
        {
            get
            {
                return _enemyFirstTakenCard;
            }
            set
            {
                _enemyFirstTakenCard = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EnemyFirstTakenCard"));
            }
        }

        public Card EnemySecondTakenCard
        {
            get
            {
                return _enemySecondTakenCard;
            }
            set
            {
                _enemySecondTakenCard = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EnemySecondTakenCard"));
            }
        }

        public Card MyFirstTakenCard
        {
            get
            {
                return _myFirstTakencard;
            }
            set
            {
                _myFirstTakencard = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MyFirstTakenCard"));
            }
        }

        public Card MySecondTakenCard
        {
            get
            {
                return _mySecondTakenCard;
            }
            set
            {
                _mySecondTakenCard = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MySecondTakenCard"));
            }
        }


        public ObservableCollection<Card> Deck
        {
            get
            {
                return _deck;
            }
            set
            {
                _deck = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Deck"));
            }
        }

        public ObservableCollection<Card> MyPile
        {
            get
            {
                return _myPile;
            }
            set
            {
                _myPile = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MyPile"));
            }
        }

        public ObservableCollection<Card> EnemyPile
        {
            get
            {
                return _enemyPile;
            }
            set
            {
                _enemyPile = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EnemyPile"));
            }
        }

        public Card EnemyThrownCard
        {
            get
            {
                return _enemyThrownCard;
            }
            set
            {
                _enemyThrownCard = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EnemyThrownCard"));
            }
        }

        public Card MyThrownCard
        {
            get
            {
                return _myThrownCard;
            }
            set
            {
                _myThrownCard = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MyThrownCard"));
            }
        }


        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Status"));
            }
        }


        public War(ObservableCollection<Card> deck)
        {
            _deck = deck;
            _myPile = new ObservableCollection<Card>();
            _enemyPile = new ObservableCollection<Card>();
        }




        public void GiveOutCards()
        {
            for (int i = 0; i < Deck.Count(); i++)
            {
                if (i % 2 == 0)
                {
                    MyPile.Add(Deck[i]);
                }
                else
                {
                    EnemyPile.Add(Deck[i]);
                }
            }
        }


        public void ThrowCard()
        {
            if (MyPile.Count != 0 && EnemyPile.Count != 0)
            {
                MyThrownCard = MyPile.First();
                EnemyThrownCard = EnemyPile.First();

                if (MyThrownCard.FigureNumber < EnemyThrownCard.FigureNumber)
                {
                    Status = "Karty zabiera komputer";
                    TakeCard(EnemyPile, MyPile, MyThrownCard);
                }
                else if (MyThrownCard.FigureNumber == EnemyThrownCard.FigureNumber)
                {
                    var mySecondCard = MyPile.ElementAt(1);
                    var enemySecondCard = EnemyPile.ElementAt(1);
                    var myThirdCard = MyPile.ElementAt(2);
                    var enemyThirdCard = EnemyPile.ElementAt(2);

                    if (myThirdCard.FigureNumber < enemyThirdCard.FigureNumber)
                    {
                        Status = "Wojna!!! \n Karty zabiera komputer";
                        TakeCard(EnemyPile, MyPile, MyThrownCard);
                        TakeCard(EnemyPile, MyPile, mySecondCard);
                        TakeCard(EnemyPile, MyPile, myThirdCard);
                    }
                    else
                    {
                        Status = "Wojna!!! \n Zabierasz karty";
                        TakeCard(MyPile, EnemyPile, EnemyThrownCard);
                        TakeCard(MyPile, EnemyPile, enemySecondCard);
                        TakeCard(MyPile, EnemyPile, enemyThirdCard);
                    }
                }
                else
                {
                    Status = "Zabierasz karty";
                    TakeCard(MyPile, EnemyPile, EnemyThrownCard);
                }
            }
        }

        public void TakeCard(ObservableCollection<Card> winnerPile, ObservableCollection<Card> loserPile, Card wonCard)
        {
            winnerPile.Add(winnerPile.First());
            winnerPile.RemoveAt(0);
            winnerPile.Add(wonCard);
            loserPile.RemoveAt(0);
        }


        public void TakeWonCards()
        {
            if (MyThrownCard.FigureNumber < EnemyThrownCard.FigureNumber)
            {
                EnemyFirstTakenCard = MyThrownCard;
                EnemySecondTakenCard = EnemyThrownCard;
            }
            else
            {
                MyFirstTakenCard = EnemyThrownCard;
                MySecondTakenCard = MyThrownCard;
            }
        }


        public void ResetGame(ObservableCollection<Card> deck)
        {
            Deck = deck;
            MyThrownCard = null;
            EnemyThrownCard = null;
            MyFirstTakenCard = null;
            MySecondTakenCard = null;
            EnemyFirstTakenCard = null;
            EnemySecondTakenCard = null;
            EnemyPile.Clear();
            MyPile.Clear();
            GiveOutCards();
        }

        /*  public void Play()
          {
              GiveOutCards();

              //Console.WriteLine("Dowolny klawisz zaczyna grę!");
              //Console.ReadKey();
              //Console.Clear();

              while (_myCards.Count != 0 && _enemyCards.Count != 0)
              {
                  var enemyCard = _enemyCards.Peek();
                  var myCard = _myCards.Peek();

                  //Console.WriteLine($"Komputer rzuca: {enemyCard.Figure} {enemyCard.Color}");
                  //Console.WriteLine($"Rzucasz: {myCard.Figure} {myCard.Color}");

                  if (myCard.FigureNumber < enemyCard.FigureNumber)
                  {
                      //Console.WriteLine("\nKarty zabiera komputer");
                      TakeCards(_myCards, _enemyCards, myCard);
                  }
                  else if (myCard.FigureNumber == enemyCard.FigureNumber)
                  {
                      //Console.WriteLine("\nWalka!!!");

                      try
                      {
                          var enemySecondCard = _enemyCards.ElementAt(1);
                          var mySecondCard = _myCards.ElementAt(1);

                          var enemyThirdCard = _enemyCards.ElementAt(2);
                          var myThirdCard = _myCards.ElementAt(2);

                          //Console.WriteLine($"Komputer rzuca: {enemySecondCard.Figure} {enemySecondCard.Color} (Odwrócona)");
                          //Console.WriteLine($"Rzucasz: {mySecondCard.Figure} {mySecondCard.Color} (Odwrócona)");

                          //Console.WriteLine($"\nKomputer rzuca: {enemyThirdCard.Figure} {enemyThirdCard.Color}");
                          //Console.WriteLine($"Rzucasz: {myThirdCard.Figure} {myThirdCard.Color}");

                          if (myThirdCard.FigureNumber < enemyThirdCard.FigureNumber)
                          {
                              //Console.WriteLine("\nKarty zabiera komputer");
                              TakeCards(_myCards, _enemyCards, myCard);
                              TakeCards(_myCards, _enemyCards, mySecondCard);
                              TakeCards(_myCards, _enemyCards, myThirdCard);
                          }
                          else
                          {
                              //Console.WriteLine("\nZabierasz karty");
                              TakeCards(_enemyCards, _myCards, enemyCard);
                              TakeCards(_enemyCards, _myCards, enemySecondCard);
                              TakeCards(_enemyCards, _myCards, enemyThirdCard);
                          }
                      }
                      catch (ArgumentOutOfRangeException)
                      {
                          if (_myCards.Count < _enemyCards.Count)
                          {
                              //Console.WriteLine("Przegrałeś!!!");
                          }
                          else
                          {
                              //Console.WriteLine("Wygrałeś!!!");
                          }
                          Environment.Exit(0);
                      }
                  }
                  else
                  {
                      //Console.WriteLine("\nZabierasz karty");
                      TakeCards(_enemyCards, _myCards, enemyCard);
                  }
                  //PrintStatistics();
              }

              if (_myCards.Count == 0)
              {
                  //Console.WriteLine("Przegrałeś!!!");
              }
              else
              {
                  //Console.WriteLine("Wygrałeś!!!");
              }
              //Console.WriteLine("Dowolny klawisz zamyka okno");
              //Console.ReadKey();
          }
          */
    }
}
