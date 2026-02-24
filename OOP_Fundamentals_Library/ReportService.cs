using System;

namespace OOP_Fundamentals_Library
{
    public interface IReportGenerator
    {
        void GenerateReport(Person person);
    }

    public class ReportService : IReportGenerator
    {
        public void GenerateReport(Person person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            Console.WriteLine($"\n Report for {person.Name}");

            // Полиморфное поведение
            switch (person)
            {
                case Manager manager:
                    GenerateManagerReport(manager);
                    break;
                case Employee employee:
                    GenerateEmployeeReport(employee);
                    break;
                case Customer customer:
                    GenerateCustomerReport(customer);
                    break;
                default:
                    person.PrintInfo();
                    break;
            }
        }

        private void GenerateEmployeeReport(Employee employee)
        {
            Console.WriteLine($"Employee: {employee.Name}");
            Console.WriteLine($"  Age: {employee.Age}");
            Console.WriteLine($"  Position: {employee.Position}");
            Console.WriteLine($"  Salary: {employee.Salary:C}");
        }

        private void GenerateManagerReport(Manager manager)
        {
            GenerateEmployeeReport(manager);
            Console.WriteLine($"  Department: {manager.Department}");
            Console.WriteLine($"  Team Size: {manager.Team.Count}");

            if (manager.Team.Any())
            {
                Console.WriteLine("  Team Members:");
                foreach (var member in manager.Team)
                {
                    Console.WriteLine($"    - {member.Name} ({member.Position})");
                }
            }
        }

        private void GenerateCustomerReport(Customer customer)
        {
            Console.WriteLine($"Customer: {customer.Name}");
            Console.WriteLine($"  Age: {customer.Age}");
            Console.WriteLine($"  Total purchases: {customer.PurchaseHistory.Count}");

            if (customer.PurchaseHistory.Any())
            {
                Console.WriteLine("  Purchase History:");
                foreach (var item in customer.PurchaseHistory)
                {
                    Console.WriteLine($"    - {item}");
                }
            }
        }
    }
}