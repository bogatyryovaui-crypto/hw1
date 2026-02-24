using System;
using System.Xml.Linq;

namespace OOP_Fundamentals_Library
{
    public class Employee : Person
    {
        private decimal _salary;
        private string _position;

        public decimal Salary
        {
            get => _salary;
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Salary cannot be negative");
                _salary = value;
            }
        }

        public string Position
        {
            get => _position;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Position cannot be empty");
                _position = value;
            }
        }

        public Employee(string name, int age, decimal salary, string position)
            : base(name, age)
        {
            Salary = salary;
            Position = position;
        }

        public virtual void IncreaseSalary(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Increase amount cannot be negative");
            Salary += amount;
        }

        public virtual void ProcessPayroll()
        {
            Console.WriteLine($"Processing payroll for {Name}: {Salary:C}");
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"  Position: {Position}, Salary: {Salary:C}");
        }
    }
}