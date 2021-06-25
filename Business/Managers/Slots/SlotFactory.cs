using Contracts.Enums;


namespace Business.Managers.Slots
{
    public class SlotFactory
    {
        //Detrmine which slot based on user choice
        public static ISlotManager GetSlotManager(SlotType slotType)
        {

            return slotType switch
            {
                SlotType.CoinSlot => new CoinSlotManager(),
                SlotType.NotesSlot => new NoteSlotManager(),
                SlotType.DebitSlot => new CardSlotManager(),
                _ => null,
            };
        }

    }
}
