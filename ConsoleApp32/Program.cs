using System.Runtime.InteropServices;

namespace ConsoleApp32
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            Console.Write("Enter salary: ");
            double avgSalary = double.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            using(StreamReader reader = File.OpenText(path))
            {
                while (!reader.EndOfStream)
                {
                    string[] strings = reader.ReadLine().Split(',');
                    string name = strings[0];
                    string email = strings[1];
                    double salary = Double.Parse(strings[2]);

                    employees.Add(new Employee(name, email,salary));
                }

                var avg = employees.Where(p => p.Salary > avgSalary).OrderBy(p => p.Email).Select(p => p.Email);

                Console.WriteLine("Email of people whose salary is greater than " + avgSalary);

                foreach (string employee in avg) {
                    Console.WriteLine(employee);
                }

                var sum = employees.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);

                Console.WriteLine("Sum of salary of people whose name stars with 'M': " + sum);
            }
        }
    }
}
