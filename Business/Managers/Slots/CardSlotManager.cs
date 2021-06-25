using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers.Slots
{
   public class CardSlotManager : ISlotManager
    {
        public Money GetMoney(string money)
        { 
            throw new NotImplementedException();
        }

        public List<Money> GetValues()
        {
            throw new NotImplementedException();
        }

        public bool Validate(string money)
        {
            throw new NotImplementedException();
        }
    }
}
