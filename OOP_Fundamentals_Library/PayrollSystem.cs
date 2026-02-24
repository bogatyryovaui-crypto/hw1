namespace OOP_Fundamentals_Library
{
    public interface IPayrollProcessor
    {
        void ProcessSalary(Employee employee);
        decimal CalculateBonus(Employee employee);
    }

    public class PayrollSystem : IPayrollProcessor
    {
        public void ProcessSalary(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            Console.WriteLine($"Processing salary for {employee.Name}: {employee.Salary:C}");

            // Полиморфное поведение через виртуальный метод
            employee.IncreaseSalary(employee is Manager ? 2000 : 1000);
        }

        public decimal CalculateBonus(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            decimal bonus = employee switch
            {
                Manager => employee.Salary * 0.2m,
                _ => employee.Salary * 0.1m
            };

            return bonus;
        }
    }
}