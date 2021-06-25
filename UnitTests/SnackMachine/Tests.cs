using Business.Managers;
using Contracts.Enums;
using Contracts.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    public class Tests
    {
        Mock<InventoryManager> _inventory;
        Mock<SnackMachineManager> _snackMachineManager;

        List<Snack> snacks;
        List<Money> notes;

        [SetUp]
        public void Setup()
        {
            _inventory = new();
            snacks = new()
            {
                new Snack { Id = 1, Name = "Snack 1", Price = 19 },
                new Snack { Id = 2, Name = "Snack 2", Price = 20.5 }
            };

            notes = new()
            {
                new Money { Name = "20$", Amount = 20 }
            };


            _snackMachineManager = new(_inventory.Object);
            _inventory.Setup(x => x.GetAllSnacks())
             .Returns(snacks);

        }

        [Test]
        public void Successful_Payment_Using_NotesOnlyWithChange()
        {
            var snack = snacks.First();
            var note = notes.First();

            _inventory.Setup(x => x.CheckIfSnackExist(It.IsAny<int>())).Returns(true);
            _inventory.Setup(x => x.GetSnack(It.IsAny<int>())).Returns(snack);

            _snackMachineManager.Setup(x => x.SelectSnack()).Returns(snack.Id);
            _snackMachineManager.Setup(x => x.ChooseSlotType()).Returns((int)SlotType.NotesSlot);
            _snackMachineManager.Setup(x => x.InsertMoney()).Returns((note.Name));

            //Act
            _snackMachineManager.Object.DisplaySnacks();

            //Assert & Verfiy
            _snackMachineManager.Verify(m => m.DispensesSnack(snack.Name), Times.Once);
            Assert.That(_snackMachineManager.Object.GetChangeAmount(snack.Price), Is.EqualTo(note.Amount - snack.Price));


        }

        [Test]
        public void Successful_Payment_Using_NotesAndCoinsWithoutChange()
        {
            var snack = new Snack { Id = 2, Name = "Snack 2", Price = 20.5 };
            var coin = new Money { Name = "50c", Amount = .5 };
            var note = new Money { Name = "20$", Amount = 20 };


            _inventory.Setup(x => x.CheckIfSnackExist(It.IsAny<int>())).Returns(true);
            _inventory.Setup(x => x.GetSnack(It.IsAny<int>())).Returns(snack);

            _snackMachineManager.Setup(x => x.SelectSnack()).Returns(snack.Id);
            _snackMachineManager.SetupSequence(x => x.ChooseSlotType())
                .Returns((int)SlotType.NotesSlot)
                .Returns((int)SlotType.CoinSlot);
            _snackMachineManager.SetupSequence(x => x.InsertMoney())
                .Returns((note.Name))
                .Returns((coin.Name));

            //Act
            _snackMachineManager.Object.DisplaySnacks();

            //Assert & Verfiy
            _snackMachineManager.Verify(m => m.DispensesSnack(snack.Name), Times.Once);
            Assert.That(_snackMachineManager.Object.GetChangeAmount(snack.Price), Is.EqualTo(0));


        }


        [Test]
        public void Successful_Payment_Using_NotesAndCoinsWithChange()
        {
            var snack = new Snack { Id = 2, Name = "Snack 2", Price = 50.2 };
            var coin = new Money { Name = "50c", Amount = 0.5 };
            var note = new Money { Name = "50$", Amount = 50 };

            _inventory.Setup(x => x.CheckIfSnackExist(It.IsAny<int>())).Returns(true);
            _inventory.Setup(x => x.GetSnack(It.IsAny<int>())).Returns(snack);

            _snackMachineManager.Setup(x => x.SelectSnack()).Returns(snack.Id);
            _snackMachineManager.SetupSequence(x => x.ChooseSlotType())
                .Returns((int)SlotType.NotesSlot)
                .Returns((int)SlotType.CoinSlot);
            _snackMachineManager.SetupSequence(x => x.InsertMoney())
                .Returns((note.Name))
                .Returns((coin.Name));

            //Act
            _snackMachineManager.Object.DisplaySnacks();

            //Assert & Verfiy
            var changedAmount = note.Amount + coin.Amount - snack.Price;
            _snackMachineManager.Verify(m => m.DispensesSnack(snack.Name), Times.Once);
            Assert.That(_snackMachineManager.Object.GetChangeAmount(snack.Price), Is.EqualTo(changedAmount));



        }


        [Test]
        public void Successful_Payment_Using_NotesOnlyWithoutChange()
        {
            /*
             * Test case using notes only with change*
             * 
             */

        }

        [Test]
        public void Successful_Payment_Using_CoinsOnlyWithoutChange()
        {
            /*
             * Test case using coins only with change*
             * 
             */

        }

        [Test]
        public void Successful_Payment_Using_CoinsOnlyWithChange()
        {
            /*
             * Test case using coins only with change*
             * 
             */
        }

        [Test]
        public void Selecting_Snack_DoesNotExist()
        {
            /*
             * Test if user select snack number does not exist*
             * 
             */
        }

       
    }
}