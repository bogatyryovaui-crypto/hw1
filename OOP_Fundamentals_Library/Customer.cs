namespace OOP_Fundamentals_Library
{
    // Абстрактный базовый класс Person
    public abstract class Person
    {
        private string _name;
        private int _age;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                _name = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 0 || value > 150)
                    throw new ArgumentException("Age must be between 0 and 150");
                _age = value;
            }
        }

        protected Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"{GetType().Name}: {Name}, {Age} years old");
        }
    }

    // Класс Customer наследуется от Person
    public class Customer : Person
    {
        private readonly List<string> _purchaseHistory = new();

        public IReadOnlyList<string> PurchaseHistory => _purchaseHistory.AsReadOnly();

        public Customer(string name, int age) : base(name, age)
        {
        }

        public void AddPurchase(string item)
        {
            if (string.IsNullOrWhiteSpace(item))
                throw new ArgumentException("Item cannot be empty");

            _purchaseHistory.Add(item);
            Console.WriteLine($"Customer {Name} purchased: {item}");
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"  Total purchases: {_purchaseHistory.Count}");
        }
    }
}