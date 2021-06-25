using Business.Managers.Slots;
using Contracts.Enums;
using Contracts.Models;
using System;
using System.Linq;

namespace Business.Managers
{
    public interface ISnackMachine
    {
        void DisplaySnacks();

    }

    public class SnackMachineManager : ISnackMachine
    {
        private readonly IInventoryManager _inventory;
        private double insertedMoney = 0;
        private ISlotManager _slotManager;
        public SnackMachineManager(IInventoryManager inventory)
        {
            _inventory = inventory;
        }

        public void DisplaySnacks()
        {

            var snacks = _inventory.GetAllSnacks();
            foreach (var value in snacks)
            {
                if (value.Id % 5 == 0)
                    Console.WriteLine($"{ value.Id} ");
                else
                    Console.Write($"{ value.Id} ");

            }

            CheckSnackAvalibilty();
        }

        private void CheckSnackAvalibilty()
        {
            int snackId = SelectSnack();
            while (!_inventory.CheckIfSnackExist(snackId))
            {
                Console.WriteLine("The item you selected is not avaliable, please select another item.");
                snackId = SelectSnack();
            }

            var snack = _inventory.GetSnack(snackId);

            Console.WriteLine($"The item price is {snack.Price} ");

            PaymentProcesss(snack);

        }

        private void PaymentProcesss(Snack snack)
        {
            var slotTypes = Enum.GetValues(typeof(SlotType)).Cast<SlotType>();

            while (insertedMoney < snack.Price)
            {
                Console.WriteLine($" Money = { insertedMoney } ");

                Console.WriteLine($"Please Choose Slot :");

                foreach (var value in slotTypes)
                {
                    Console.WriteLine($"{ (int)value }: {value} ");
                }

                var slotType = (SlotType)ChooseSlotType();

                ValidateSlotMoney(slotType);
            }

            DispensesSnack(snack.Name);

            Console.WriteLine($" Change = { GetChangeAmount(snack.Price) } ");


        }


        private void ValidateSlotMoney(SlotType slotType)
        {
            _slotManager = SlotFactory.GetSlotManager(slotType);

            Console.WriteLine($"You Can insert these values : ");

            foreach (var value in _slotManager.GetValues())
            {
                Console.Write($" {value.Name} ");
            }

            Console.WriteLine("\n Please insert the money :");

            var money = InsertMoney();
            
            if (!_slotManager.Validate(money))
                Console.WriteLine($"Money is not acceptable , Please try again");
            else
                insertedMoney += _slotManager.GetMoney(money).Amount;
        }

        public virtual void DispensesSnack(string snackName)
        {
            Console.WriteLine($" Dispenses the snack {snackName} \n ");
        }

        public double GetChangeAmount(double snackPrice)
        {
            return insertedMoney - snackPrice;
        }

        public virtual int ChooseSlotType()
        {
            return int.Parse(Console.ReadLine());
        }


        public virtual string InsertMoney()
        {
            return Console.ReadLine();
        }

        public virtual int SelectSnack()
        {
            Console.WriteLine("Please Select Snack Number :");
            return int.Parse(Console.ReadLine());
        }

        private SlotType GetSlotType(string money)
        {
            return (SlotType)Enum.Parse(typeof(SlotType), money);
        }

    }
}
