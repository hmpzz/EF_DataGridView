using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Base_Bll<T> where T:class
    {
        protected internal Base_Dal<T> base_dal;

        public Base_Bll()
        {
            base_dal = new Base_Dal<T>();
        }

        public int Add(T model)
        {
             base_dal.Add(model);
            return base_dal.save();
        }

        public int Del(T model)
        {
             base_dal.Del(model);
            return base_dal.save();
        }

        public int Modify(T model, params string[] proName)
        {
             base_dal.Modify(model, proName);
            return base_dal.save();
        }

        public int Modify(T model)
        {
            base_dal.Modify(model);
            return base_dal.save();
        }


        public List<T> GetList()
        {
            return base_dal.GetList();
        }

        public List<T> GetListNoTracking()
        {
            return base_dal.GetListNoTracking();
        }

    }
}
