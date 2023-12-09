using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14.HomeWork
{
    class Program
    {
        static void Main()
        {
            int numberOfPlayers = 2;
            Game game = new Game(numberOfPlayers);
            game.StartGame();

            Console.ReadLine();
        }
    }

    class Game
    {
        private List<Player> players = new List<Player>();
        private List<Karta> koloda = new List<Karta>();

        public Game(int numberOfPlayers)
        {
            CreateKoloda();
            ShuffleKoloda();
            CreatePlayers(numberOfPlayers);
            RazdatKarty();
        }

        private void CreateKoloda()
        {
            string[] masts = { "Черви", "Бубны", "Крести", "Пики" };
            string[] tips = { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };

            foreach (var mast in masts)
            {
                foreach (var tip in tips)
                {
                    koloda.Add(new Karta(mast, tip));
                }
            }
        }

        private void ShuffleKoloda()
        {
            Random random = new Random();
            koloda = koloda.OrderBy(x => random.Next()).ToList();
        }

        private void CreatePlayers(int numberOfPlayers)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players.Add(new Player(i));
            }
        }

        private void RazdatKarty()
        {
            int playerIndex = 0;

            foreach (var karta in koloda)
            {
                players[playerIndex].Koloda.Add(karta);
                playerIndex = (playerIndex + 1) % players.Count;
            }
        }

        public void StartGame()
        {
            while (!GameFinished())
            {
                List<Karta> roundCards = new List<Karta>();

                // Игроки кладут по одной карте.
                foreach (var player in players)
                {
                    Karta card = player.Koloda.First();
                    roundCards.Add(card);
                    player.Koloda.RemoveAt(0);

                    Console.WriteLine($"{player} кладет {card.Mast} {card.Tip}");
                }

                Player winner = DetermineRoundWinner(roundCards);

                // Проверка на ничью
                if (winner == null)
                {
                    // Логика для ничьи, если нужна
                    // Например, можно возвращать карты игрокам или перемешивать их заново
                    Console.WriteLine("Раунд завершился ничьей. Карты возвращаются игрокам.");
                    foreach (var card in roundCards)
                    {
                        players.First().Koloda.Add(card);
                    }
                }
                else
                {
                    Console.WriteLine($"Выигрывает {winner}");
                    winner.Koloda.AddRange(roundCards);
                }
            }

            Player gameWinner = DetermineGameWinner();
            Console.WriteLine($"Игру выиграл {gameWinner}");
        }

        // Определение победителя раунда
        private Player DetermineRoundWinner(List<Karta> roundCards)
        {
            return players.First(player => roundCards.All(card => card.CompareTo(player.Koloda.First()) != 0));
        }

        // Определение победителя игры
        private Player DetermineGameWinner()
        {
            return players.OrderByDescending(player => player.Koloda.Count).First();
        }

        // Проверка завершения игры
        private bool GameFinished()
        {
            // Игра завершается, когда у одного из игроков заканчиваются карты.
            return players.Any(player => player.Koloda.Count == 0);
        }
    }
}

