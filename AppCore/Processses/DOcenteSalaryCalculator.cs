using AppCore.Interfaces;
using Domain.Entities.Empleados;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Processses
{
    public class DOcenteSalaryCalculator : BaseSalaryCalculator, ISalaryCalculator
    {
        public decimal CalculateSalary(Empleado e)
        {
            decimal salary = decimal.MinValue;
            decimal inss = CalculateInss(e.Salario);
            decimal annualSalary = decimal.MinValue, ir = decimal.MinValue;
            annualSalary = CalculateAnnualSalary(e.Salario - inss);
            ir = CalculateIr(annualSalary);
            salary = salary- inss - ir;

            return salary;
        }
    }
}
