using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockPaperScisors.Entities.Exceptions
{
    public class WrongNumberOfPlayersException : ArgumentException
    {
        public WrongNumberOfPlayersException(string message) : base(message)
        {

        }
    }
}