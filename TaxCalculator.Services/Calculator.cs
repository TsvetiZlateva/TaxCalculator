using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Services
{
    public abstract class Calculator
    {
        private static decimal netSalary;
        private static readonly decimal maxTaxableIncome = 3000;
        private static readonly decimal minTaxableIncome = 1000;
        private static readonly decimal incomeTax = 0.10m;
        private static readonly decimal socialContributionTax = 0.15m;

        public static decimal FixedTax => (maxTaxableIncome - minTaxableIncome) * 0.15m;

        public static decimal CalculateNetSalary(decimal salary)
        {
            //encapsulate the calculation logic
            return NetSalary(salary);
        }

        private static decimal NetSalary(decimal salary)
        {
            if (salary == 0)
            {
                netSalary = 0;
            }
            else if (salary <= minTaxableIncome)
            {
                netSalary = salary;
            }
            else if (salary > minTaxableIncome)
            {
                var incomeTaxes = (salary - minTaxableIncome) * incomeTax;
                decimal socialContributionTaxes;

                if (salary <= maxTaxableIncome)
                {
                    socialContributionTaxes = (salary - minTaxableIncome) * socialContributionTax;                    
                }
                else
                {
                    socialContributionTaxes = FixedTax;
                }

                netSalary = salary - incomeTaxes - socialContributionTaxes;
            }

            return netSalary;
        }
    }
}
