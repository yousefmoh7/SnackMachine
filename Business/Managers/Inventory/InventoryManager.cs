using Contracts.Models;
using System.Collections.Generic;
using System.Linq;

namespace Business.Managers
{
    public interface IInventoryManager
    {
        bool CheckIfSnackExist(int snackId);

        List<Snack> GetAllSnacks();

        Snack GetSnack(int id);
    }

    public class InventoryManager : IInventoryManager
    {
        private readonly List<Snack> snacks;
        public InventoryManager()
        {
            snacks = new()
            {
                new Snack { Id = 1, Name = "S1", Price = 30.4 },
                new Snack { Id = 2, Name = "S2", Price = 30.4 },
                new Snack { Id = 3, Name = "S3", Price = 30 },
                new Snack { Id = 4, Name = "S4", Price = 30 },
                new Snack { Id = 5, Name = "S5", Price = 20 },
                new Snack { Id = 6, Name = "S6", Price = 30 },
                new Snack { Id = 7, Name = "S7", Price = 30 },
                new Snack { Id = 8, Name = "S8", Price = 30 },
                new Snack { Id = 9, Name = "S9", Price = 30 },
                new Snack { Id = 10, Name = "S10", Price = 30 },
                new Snack { Id = 11, Name = "S11", Price = 20 },
                new Snack { Id = 12, Name = "S12", Price = 30 },
                new Snack { Id = 13, Name = "S13", Price = 30 },
                new Snack { Id = 14, Name = "S14", Price = 30 },
                new Snack { Id = 15, Name = "S15", Price = 20 },
                new Snack { Id = 16, Name = "S16", Price = 30 },
                new Snack { Id = 17, Name = "S17", Price = 30 },
                new Snack { Id = 18, Name = "S18", Price = 30 },
                new Snack { Id = 19, Name = "S19", Price = 30 },
                new Snack { Id = 20, Name = "S20", Price = 30 },
                new Snack { Id = 21, Name = "S21", Price = 30 },
                new Snack { Id = 22, Name = "S22", Price = 30 },
                new Snack { Id = 23, Name = "S23", Price = 30 },
                new Snack { Id = 24, Name = "S24", Price = 30 },
                new Snack { Id = 25, Name = "S25", Price = 30 },
            };
        }

        public virtual bool CheckIfSnackExist(int snackId)
        {
            return snacks.Any(x => x.Id == snackId);
        }

        public virtual List<Snack> GetAllSnacks()
        {
            return snacks;
        }

        public virtual Snack GetSnack(int snackId)
        {
            return snacks.FirstOrDefault(x => x.Id == snackId);
        }
    }
}
