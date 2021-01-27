using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employeedetails2;

namespace EmployeeManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int input;
            int checker;
            string name;
            int age;
            double salary;
            int check = 0;
            IDictionary<int, Tuple<string, int, double>> Employees = new Dictionary<int, Tuple<string, int, double>>();
            Employee emp = new Employee();
        Enterinput:
            try
            {
                do
                {
                    Console.WriteLine(" Please enter the option\n1.Add an employee\n2.Modify an employee detail\n" +"3.Print all employee's details\n4.Print an employee detail\n5.Exit");
                    input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                        Add_Details:
                            try
                            {
                                do
                                {
                                    emp.TakeEmployeeDetailsFromUser();
                                    Employees.Add(emp.Id, Tuple.Create(emp.Name, emp.Age, emp.Salary));
                                    Console.WriteLine("To continue entering employee details enter 1, to exit enter 0");
                                    checker = Convert.ToInt32(Console.ReadLine());
                                } while (checker == 1);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("ID already exists..Retry with a different id");
                                check = 1;
                            }
                            if (check == 1)
                            {
                                check = check + 1;
                                goto Add_Details;
                            }
                            break;
                        case 2:
                        Update_details:
                            Console.WriteLine("Please enter the employee ID");
                            int idno = Convert.ToInt32(Console.ReadLine());
                            if (Employees.ContainsKey(idno))
                            {
                                foreach (var employee in Employees)
                                {
                                    if (employee.Key == idno)
                                    {
                                        Console.WriteLine("Employee ID:{0}\nName:{1}\nAge:{2}\nSalary:{3}", employee.Key, employee.Value.Item1, employee.Value.Item2, employee.Value.Item3);
                                    }
                                }
                                Employees.Remove(idno);
                                Console.WriteLine("Please enter the updated employee details");
                                Console.WriteLine("Please enter the employee name");
                                name = Console.ReadLine();
                                Console.WriteLine("Please enter the employee age");
                                age = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Please enter the employee salary");
                                salary = Convert.ToDouble(Console.ReadLine());
                                Employees.Add(idno, Tuple.Create(name, age, salary));
                            }
                            else
                            {
                                Console.WriteLine("Id does not exists");
                                goto Update_details;
                            }
                            break;
                        case 3:
                            foreach (var employee in Employees)
                            {
                                Console.WriteLine("Employee ID:{0}\nName:{1}\nAge:{2}\nSalary:{3}", employee.Key, employee.Value.Item1, employee.Value.Item2, employee.Value.Item3);
                            }
                            break;
                        case 4:
                        Reenter:
                            Console.WriteLine("Please enter the employee ID");
                            int printidno = Convert.ToInt32(Console.ReadLine());
                            if (Employees.ContainsKey(printidno))
                            {
                                foreach (var employee in Employees)
                                {
                                    if (employee.Key == printidno)
                                    {
                                        Console.WriteLine("Employee ID:{0}\nName:{1}\nAge:{2}\nSalary:{3}", employee.Key, employee.Value.Item1, employee.Value.Item2, employee.Value.Item3);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Id does not exixts");
                                goto Reenter;
                            }
                            break;
                        case 5:
                            break;

                        default:
                            Console.WriteLine("Please enter the valid option");
                            break;
                    }

                } while (input != 5);
            }
            catch (Exception)
            {
                Console.WriteLine("Retry with given option");
                check = 1;
            }
            if (check == 1)
            {
                check = 0;
                goto Enterinput;
            }
            Console.ReadKey();
        }
    }
}