using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers.Slots
{
    public class CoinSlotManager : ISlotManager
    {
        private readonly List<Money> coins;

        public CoinSlotManager()
        {
            coins = new()
            {
                new Money
                {

                    Amount = 0.1,
                    Name = "10c"
                },
                new Money
                {

                    Amount = 0.2,
                    Name = "20c"
                },
                new Money
                {

                    Amount = 0.5,
                    Name = "50c"
                },
                new Money
                {

                    Amount = 1,
                    Name = "1$"
                }
            };
        }
        
        
        public bool Validate(string money)
        {
            return coins.Any(x => x.Name == money);
        }

        public List<Money> GetValues()
        {
            return coins;
        }

        public Money GetMoney(string money)
        {
            return coins.First(x => x.Name == money);
        }
    }
}
