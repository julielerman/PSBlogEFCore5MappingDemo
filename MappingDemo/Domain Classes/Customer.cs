using System.Collections.Generic;

namespace MappingDemo
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
}
