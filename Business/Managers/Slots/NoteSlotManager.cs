using Contracts.Models;
using System.Collections.Generic;
using System.Linq;

namespace Business.Managers.Slots
{
    public class NoteSlotManager : ISlotManager
    {
        private readonly List<Money> notes;

        public NoteSlotManager()
        {
            notes = new()
            {
                new Money
                {
                    Amount = 20,
                    Name = "20$"
                },
                new Money
                {
                    Amount = 50,
                    Name = "50$"
                }
            };
        }

        public bool Validate(string money)
        {
            return notes.Any(x => x.Name == money);
        }

        public List<Money> GetValues()
        {
            return notes;
        }

        public Money GetMoney(string money)
        {
            return notes.FirstOrDefault(x => x.Name == money);
        }
    }
}
