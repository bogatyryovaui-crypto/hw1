namespace OOP_Fundamentals_Library
{
    public class Manager : Employee
    {
        private string _department;
        private readonly List<Employee> _team = new();

        public string Department
        {
            get => _department;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Department cannot be empty");
                _department = value;
            }
        }

        public IReadOnlyList<Employee> Team => _team.AsReadOnly();

        public Manager(string name, int age, decimal salary, string department)
            : base(name, age, salary, "Manager")
        {
            Department = department;
        }

        public void AddToTeam(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (employee == this)
                throw new ArgumentException("Manager cannot be added to their own team");

            _team.Add(employee);
        }

        public bool RemoveFromTeam(Employee employee)
        {
            return _team.Remove(employee);
        }

        public void AssignTask(Employee employee, string task)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (!_team.Contains(employee))
                throw new InvalidOperationException($"Employee {employee.Name} is not in the team");

            Console.WriteLine($"Manager {Name} assigning task '{task}' to {employee.Name}");
        }

        public override void IncreaseSalary(decimal amount)
        {
            // Managers get 20% higher increases
            base.IncreaseSalary(amount * 1.2m);
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"  Department: {Department}, Team size: {_team.Count}");
        }
    }
}
