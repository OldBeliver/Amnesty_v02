using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amnesty_v02
{
    class Program
    {
        static void Main(string[] args)
        {
            Prison prison = new Prison();
            prison.Work();
        }
    }

    class Prison
    {
        private List<Prisoner> _prisoners;
        private CriminalCode _criminalCode;

        public Prison()
        {
            _prisoners = new List<Prisoner>();
            _criminalCode = new CriminalCode();

            LoadPrisoners();
        }

        public void Work()
        {
            Console.WriteLine($"Святая инквизиция и их грешники\n");

            Console.WriteLine($"Грешник\tСмертный грех\n");
            for (int i = 0; i < _prisoners.Count; i++)
            {   
                _prisoners[i].ShowInfo();
                Console.WriteLine($"\n-------------------------------");
            }

            Console.WriteLine($"\nЗастенки инквизиции переполнены");

            Console.WriteLine($"Разжечь огни инквизации, для грехопадения:");

            Dictionary<int, string> rules = _criminalCode.GetDictionary();
            for (int i = 0; i < rules.Count; i++)
            {
                Console.WriteLine($"{i} - {rules[i]}");
            }

            bool result = int.TryParse(Console.ReadLine(), out int number);
            if (result)
            {
                if(number >= 0 && number <= rules.Count)
                {
                   // тут туплю с выборкой
                }
            }


            Console.ReadKey();
        }

        private void LoadPrisoners()
        {
            _prisoners.Add(new Prisoner("Кий", new List<int>() { 1, 2, 3, 7 }));
            _prisoners.Add(new Prisoner("Щек", new List<int>() { 7 }));
            _prisoners.Add(new Prisoner("Брит", new List<int>() { 3 }));
            _prisoners.Add(new Prisoner("Лех", new List<int>() { 3 }));
            _prisoners.Add(new Prisoner("Сакс", new List<int>() { 1 }));
            _prisoners.Add(new Prisoner("Тур", new List<int>() { 7 }));
            _prisoners.Add(new Prisoner("Циг", new List<int>() { 2 }));
            _prisoners.Add(new Prisoner("Степ", new List<int>() { 4 }));
            _prisoners.Add(new Prisoner("Бъёрн", new List<int>() { 7 }));
            _prisoners.Add(new Prisoner("Лев", new List<int>() { 1 }));
            _prisoners.Add(new Prisoner("Бруно", new List<int>() { 0 }));
            _prisoners.Add(new Prisoner("Рус", new List<int>() { 7 }));
            _prisoners.Add(new Prisoner("Гюнтер", new List<int>() { 4 }));
            _prisoners.Add(new Prisoner("Дарк", new List<int>() { 0 }));
            _prisoners.Add(new Prisoner("Хорив", new List<int>() { 1, 3, 7 }));
            _prisoners.Add(new Prisoner("Илай", new List<int>() { 5 }));
            _prisoners.Add(new Prisoner("Пит", new List<int>() { 6 }));
        }
    }

    class Prisoner
    {
        public string Name { get; private set; }
        public List<int> Crimes { get; private set; }
        private CriminalCode _criminalCode;

        public Prisoner(string name, List<int> crimes)
        {
            Name = name;
            Crimes = crimes;
            _criminalCode = new CriminalCode();
        }

        public void ShowInfo()
        {   
            Console.Write($"{Name} \t");
            ShowCrime();
        }

        private void ShowCrime()
        {
            for (int i = 0; i < Crimes.Count; i++)
            {  
                _criminalCode.ShowCode(Crimes[i]);
            }
            Console.Write($"\b\b.");
        }
    }

    class CriminalCode
    {   
        public Dictionary<int, string> _rules { get; private set; }

        public CriminalCode()
        {
            _rules = new Dictionary<int, string>();

            LoadRules();
        }

        private void LoadRules()
        {
            _rules.Add(0, "еретик");
            _rules.Add(1, "гордыня");
            _rules.Add(2, "зависть");
            _rules.Add(3, "чревоугодие");
            _rules.Add(4, "блуд");
            _rules.Add(5, "гнев");
            _rules.Add(6, "алчность");
            _rules.Add(7, "уныние");
        }

        public void ShowCode(int index)
        {
            Console.Write($"{_rules[index]}, ");
        }

        public Dictionary<int, string> GetDictionary()
        {
            return _rules;
        }
    }
}
