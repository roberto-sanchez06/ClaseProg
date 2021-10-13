using Domain.Entities.Empleados;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Interfaces
{
    public interface ISalaryCalculator
    {
        decimal CalculateSalary(Empleado e);
    }
}
