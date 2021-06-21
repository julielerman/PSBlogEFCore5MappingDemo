using System;
using System.Collections.Generic;

namespace MappingDemo
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public List<LineItem> LineItems { get; set; }

    }
}
