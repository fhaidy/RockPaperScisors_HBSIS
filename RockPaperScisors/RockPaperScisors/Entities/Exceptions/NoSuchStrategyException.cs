using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockPaperScisors.Entities.Exceptions
{
    public class NoSuchStrategyException : ArgumentException
    {
        public NoSuchStrategyException(string message) : base(message)
        {

        }
        
    }
}