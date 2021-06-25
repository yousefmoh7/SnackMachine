using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers.Slots
{
    public interface ISlotManager
    {
        public bool Validate(string money);

        public List<Money> GetValues();

        public Money GetMoney(string money);
    }
}
