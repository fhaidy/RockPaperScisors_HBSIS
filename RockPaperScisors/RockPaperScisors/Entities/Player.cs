using RockPaperScisors.Entities.Enums;
using RockPaperScisors.Entities.Exceptions;
using System;

namespace RockPaperScisors.Entities
{
    public class Player
    {
        public string Name { get; set; }
        public Movements Movement { get; private set;}

        public Player(string name)
        {
            Name = name;
        }

        public void ParseMovement(string movement)
        {
            try
            {
                string auxMovement = movement.ToUpper();
                Movements mov = (Movements)Enum.Parse(typeof(Movements), auxMovement);
                Movement = mov;
            }
            catch (Exception)
            {
                throw new NoSuchStrategyException("There is no such strategy: " + movement + ". <br><br>The valid options are: R, P, S. (case insensitive)");
            }
            
        }
    }
}