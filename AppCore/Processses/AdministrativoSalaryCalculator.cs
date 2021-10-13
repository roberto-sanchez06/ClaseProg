using AppCore.Interfaces;
using Domain.Entities.Empleados;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Processses
{
    public class AdministrativoSalaryCalculator : BaseSalaryCalculator, ISalaryCalculator
    {
        public decimal CalculateSalary(Empleado e)
        {
            decimal salary = decimal.MinValue;
            decimal inss = CalculateInss(e.Salario);
            decimal annualSalary = decimal.MinValue, ir = decimal.MinValue, partialSalary = decimal.MinValue;
            partialSalary = (e.Salario + CalculateExtaHourSalary(((Administrativo)e).HorasExtras, CalculateSalaryPerHour(e.Salario)));
            annualSalary = CalculateAnnualSalary(partialSalary - inss);
            ir = CalculateIr(annualSalary);
            salary = partialSalary - inss - ir;

            return salary;
        }
        private decimal CalculateSalaryPerHour(decimal salary)
        {
            return salary / 160;
        }

        private decimal CalculateExtaHourSalary(float horasExtras, decimal salaryPerHour)
        {
            return (decimal)horasExtras * salaryPerHour;
        }
    }
}
