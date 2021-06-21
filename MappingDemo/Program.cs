using System;
using System.Collections.Generic;
using System.Linq;

namespace MappingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var scalarCustomers = QueryWithScalar();
            var tvfCustomers= QueryWithTFV();
        }

        private static List<CustWithTotalStruct> QueryWithScalar()
        {
            using var _context = new SalesContext();
            return _context.Customers.Select
              (c => new CustWithTotalStruct(c.Name,
                                      _context.TotalSpentByCustomer(c.CustomerId)
              )).ToList();

        }

        private static List<CustWithTotalClass> QueryWithTFV()
        {
            var _context = new SalesContext();
            return _context.NameAndTotalSpentByCustomer().Where(c => c.TotalSpent > 100).ToList();
            
        }
    }
}
