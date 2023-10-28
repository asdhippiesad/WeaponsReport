using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WeaponsReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.Work();

            Console.ReadKey();
        }

    }

    class Menu
    {
        private IEnumerable<Soldier> _soldiers = new List<Soldier>();

        public Menu()
        {
            _soldiers = new List<Soldier>
            {
                new Soldier("Новиков", "АК-47", "Рядовой", 12),
                new Soldier("Павлов","M4", "Сержант", 24),
                new Soldier("Козлов", "M16", "Лейтенант", 36),
                new Soldier("Степанов", "AK-47", "Рядовой", 18),
                new Soldier("Никитин", "SCAR-H", "Капитан", 48)
            };
        }

        public void Work()
        {
            Console.WriteLine("Изначальный список: ");
            ShowSoldiers(_soldiers);
            Console.WriteLine("___________");

            Console.WriteLine("Список по имени и по званию: ");
            GetNamesAndRanks(_soldiers);
            Console.WriteLine("____________");
        }

        private void GetNamesAndRanks(IEnumerable<Soldier> soldiers)
        {
            var filteredSoldier = soldiers.Select(soldier => new { Name = soldier.Name, Title = soldier.Title});

            foreach (var soldier in soldiers)
            {
                Console.WriteLine($"{soldier.Name}, {soldier.Title}");
            }
        }

        private void ShowSoldiers(IEnumerable<Soldier> soldiers)
        {
            int soldiersNumber = 1;

            if (soldiers.Any())
            {
                foreach (var soldier in soldiers)
                {
                    Console.WriteLine($"{soldiersNumber}. {soldier.Name}, {soldier.Weapon}, {soldier.Title}, {soldier.ServiceDurationMonth}");
                    soldiersNumber++;
                }
            }
        }
    }

    class Soldier
    {
        public Soldier(string name, string weapon, string title, int serviceDurationMonth)
        {
            Name = name;
            Weapon = weapon;
            Title = title;
            ServiceDurationMonth = serviceDurationMonth;
        }

        public string Name { get; private set; }
        public string Weapon { get; private set; }
        public string Title { get; private set; }
        public int ServiceDurationMonth { get; private set; }
    }
}
