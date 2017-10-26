using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class Order_Bll:Base_Bll<Order>
    {

        private Order_Dal order_dal;


        public Order_Bll()
        {
            //base.base_dal;
            //order_dal = new Order_Dal(base.base_dal);
            order_dal = new Order_Dal(base.base_dal);


        }

        //public List<Order> GetList()
        //{
        //    List<Order> lo = new List<Order>();

        //    lo= order_dal.GetList();
            
        //    return lo;
        //}


        public void saveLO(List<Order> lo)
        {

            List<Order> lo_all = new List<Order>();
            lo_all = GetListNoTracking();



            try
            {


                List<Order> order_new = (from a in lo
                                         where a.id!=0
                                         select a
                                         
                                         ).ToList();





                foreach (Order item in order_new)
                {
                         
                    order_dal.Modify(item);
                }



                List<Order> order_new1 = (from a1 in lo_all
                                          join b1 in lo
                                         on new { a1.id } equals new { b1.id }
                                         into x1
                                         from b1 in x1.DefaultIfEmpty()
                                         where b1==null
                                         select a1).ToList();
                foreach (Order item in order_new1)
                {
                    order_dal.Del(item);
                }


                List<Order> order_new2 = (from a2 in lo
                                          where a2.id == 0
                                          select a2).ToList();
                foreach (Order item in order_new2)
                {
                    order_dal.Add(item);
                }


                order_dal.save();
            }
            catch (Exception ex) 
            {

                throw;
            }

            //order_dal.saveLO(lo);
        }
    }
}
