using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;

namespace WPF_Binding_and_Update
{
    partial class NotWindEmplyeeDataContext
    {

        public IEnumerable<Employee> GetallEmp()
        {
            var items = from emp in Employees
                        orderby emp.LastName
                        select emp;

            return items;
        }
    }
}
