using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Order:IEntity
    {
        public int Orderıd{ get; set; }
        public string Customerıd { get; set; }
        public int Employeeıd { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipCity { get; set; }
       

    }
}
