using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Army army = new Army();
        }
    }

    class Army
    {
        private List<Soldier> _firstSoldiers = new List<Soldier> { new Soldier("Иванов"), new Soldier("Баранов"), new Soldier("Петров"), new Soldier("Борисов") };
        private List<Soldier> _secondSoldiers = new List<Soldier>();

        public Army()
        {
            Console.WriteLine("Первый отряд:");
            ShowList(_firstSoldiers);
            Transfer();
            Console.WriteLine(" ");
            Console.WriteLine("Первый отряд:");
            ShowList(_firstSoldiers);
            Console.WriteLine(" ");
            Console.WriteLine("Второй отряд:");
            ShowList(_secondSoldiers);
        }

        private void Transfer()
        {
            var soldiers = _firstSoldiers.Where(soldier => soldier.Name.StartsWith("Б"));
            _secondSoldiers = _secondSoldiers.Union(soldiers).ToList();
            _firstSoldiers = _firstSoldiers.Except(soldiers).ToList();
        }

        private void ShowList(List<Soldier> list)
        {
            foreach (var soldier in list)
            {
                Console.WriteLine(soldier.Name);
            }
        }
    }

    class Soldier
    { 
        public string Name { get; private set; }

        public Soldier(string name)
        {
            Name = name;
        }
    }
}