using System;
using TaxCalculator.Services;

namespace TaxCalculator.App
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal salary;

            //show readable errors for user
            try            
            {
                Console.Write("Please enter gross salary: ");
                salary = Decimal.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            //using abstract class Calculator whith static method CalculateNetSalary, 
            //because we don't need to instantiate Calculator
            decimal netSalary = Calculator.CalculateNetSalary(salary);
            Console.WriteLine($"Net salary is: {netSalary}");
        }
    }
}
