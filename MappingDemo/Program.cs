﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MappingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
          
      
            var _context = new SalesContext();
            var tvfresults= _context.NameAndTotalSpentByCustomer().Where(c => c.TotalSpent > 100).ToList();
            
        }
    }
}
