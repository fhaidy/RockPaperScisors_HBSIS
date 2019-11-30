using System.Collections.Generic;
using RockPaperScisors.Entities.Exceptions;

namespace RockPaperScisors.Entities
{
    public static class Tournament
    {
        //public Player Winner{ get; set; }
        //public List<Player> Players { get; set; } = new List<Player>();

        //public Tournament()
        //{
        //}

        //public void AddPlayer(Player player)
        //{
        //    Players.Add(player);
        //}

        //public void AddDefaultPlayers()
        //{
        //    Players.Add(new Player("Armando", Enums.Movements.P));
        //    Players.Add(new Player("Dave", Enums.Movements.S));
        //    Players.Add(new Player("Richard", Enums.Movements.R));
        //    Players.Add(new Player("Michael", Enums.Movements.S));
        //    Players.Add(new Player("Allen", Enums.Movements.S));
        //    Players.Add(new Player("Omer", Enums.Movements.P));
        //    Players.Add(new Player("David E.", Enums.Movements.R));
        //    Players.Add(new Player("Richard X.", Enums.Movements.P));
        //}

        public static Player RpsTournamentWinner(List<Player> players)
        {
            Player roundWinner;
            List<Player> winners = new List<Player>();
            if(players.Count > 2)
            {
                List<Player> auxList = new List<Player>();
                auxList.Add(players[0]);
                auxList.Add(players[1]);
                roundWinner = RpsGameWinner(auxList);
                players.RemoveRange(0, 2);
                auxList.Clear();
                auxList.Add(roundWinner);
                auxList.Add(RpsTournamentWinner(players));

                return RpsGameWinner(auxList);
            }
            else
            {
                List<Player> auxList = new List<Player>();
                auxList.Add(players[0]);
                auxList.Add(players[1]);
                return RpsGameWinner(auxList);
            }
        }

        public static Player RpsGameWinner(List<Player> players)
        {
            if(players.Count != 2){
                throw new WrongNumberOfPlayersException("The number of players can't be different of 2.");
            }
            return CheckWinner(players.ToArray());
        }

        private static Player CheckWinner(params Player[] players)
        {
            if (players[0].Movement.ToString().Equals("R") && players[1].Movement.ToString().Equals("S"))
            {
                return players[0];
            }
            else if (players[0].Movement.ToString().Equals("R") && players[1].Movement.ToString().Equals("P"))
            {
                return players[1];
            }
            else if (players[0].Movement.ToString().Equals("P") && players[1].Movement.ToString().Equals("S"))
            {
                return players[1];
            }
            else if (players[0].Movement.ToString().Equals("P") && players[1].Movement.ToString().Equals("R"))
            {
                return players[0];
            }
            else if (players[0].Movement.ToString().Equals("S") && players[1].Movement.ToString().Equals("P"))
            {
                return players[0];
            }
            else if (players[0].Movement.ToString().Equals("S") && players[1].Movement.ToString().Equals("R"))
            {
                return players[1];
            }
            else
            {
                return players[0];
            }
        }
    }
}