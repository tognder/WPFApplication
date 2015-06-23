using System.Data.Linq;
using System.Linq;
using System.Collections.Generic;

namespace ListBoxType
{
    partial class EmployeesDataContext
    {

        public IEnumerable<Employee> GetAllEmp()
        {
            var items = from emp in Employees
                        orderby emp.LastName
                        select emp;

            return items;
        }

    }
}
