using System.Runtime.InteropServices;

namespace ConsoleApp32
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

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


            }
        }
    }
}
