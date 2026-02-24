namespace OOP_Fundamentals_Library
{
    internal class ProgramExample
    {
        static void Main(string[] args)
        {
            // Создание объектов с использованием конструкторов
            var customer = new Customer("John", 30);
            var employee = new Employee("Alice", 25, 50000m, "Developer");
            var manager = new Manager("Bob", 40, 80000m, "IT");

            // Добавление сотрудника в команду менеджера
            manager.AddToTeam(employee);

            // Покупки клиента
            customer.AddPurchase("Laptop");
            customer.AddPurchase("Mouse");

            // Полиморфный вызов PrintInfo()
            Console.WriteLine("\n Information ");
            customer.PrintInfo();
            employee.PrintInfo();
            manager.PrintInfo();

            // Назначение задачи
            manager.AssignTask(employee, "Fix bug #123");

            // Обработка зарплаты
            Console.WriteLine("\n Payroll Processing");
            var payroll = new PayrollSystem();
            payroll.ProcessSalary(employee);
            payroll.ProcessSalary(manager);

            // Расчет бонусов
            Console.WriteLine("\nBonus Calculation");
            Console.WriteLine($"Employee bonus: {payroll.CalculateBonus(employee):C}");
            Console.WriteLine($"Manager bonus: {payroll.CalculateBonus(manager):C}");

            // Генерация отчетов
            Console.WriteLine("\nReports");
            var reportService = new ReportService();
            reportService.GenerateReport(employee);
            reportService.GenerateReport(manager);
            reportService.GenerateReport(customer);
        }
    }
}