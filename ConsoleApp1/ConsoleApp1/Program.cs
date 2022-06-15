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
            ShowList(_firstSoldiers);
            Console.WriteLine(" ");
            _secondSoldiers = Transfer();
            ShowList(_secondSoldiers);
        }

        private List<Soldier> Transfer()
        {
            var sorted = _firstSoldiers.OrderBy(soldier => soldier.Name);
            var result = sorted.TakeWhile(soldier => soldier.Name.StartsWith("Б"));
            return result.ToList();
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