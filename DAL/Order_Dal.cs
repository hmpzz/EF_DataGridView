using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;


namespace DAL
{
    public class Order_Dal:Base_Dal<Order>
    {

        public Order_Dal(Base_Dal<Order> BD):base(BD)
        {
        }


        //public List<Order> GetList () 
        //{
            
        //    return db.order.ToList();

        //}

        public void saveLO(List<Order> lo)
        {
            foreach (Order item  in lo)
            {
                Console.WriteLine(db.Entry(item).State);
            }
        }
    }
}
