using System.Linq;
using System.Collections.Generic;

namespace ListBoxFiltering
{
    partial class CustomerDataContextDataContext
    {

        public IEnumerable<Customer>GetAllCustomer()
        {
            var items = from cus in Customers
                        orderby cus.ContactName
                        select cus;

            return items.ToList();
        }
    }
}
