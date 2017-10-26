using Dal;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Base_Dal<T> where T:class
    {
        protected internal Context db;

        public Base_Dal()
        {
            db = new Context();
        }

        public Base_Dal(Base_Dal<T> bd)
        {
            db = bd.db;
        }
        


        public void Add(T model)
        {
            db.Set<T>().Add(model);
            db.Set<T>().Add(model);

            
            //return db.SaveChanges();
        }
        public void Del(T model)
        {
            db.Set<T>().Attach(model);
            db.Set<T>().Remove(model);
            //return db.SaveChanges();
        }
        public void Modify(T model, params string[] proName)
        {
            DbEntityEntry<T> entityEntry = db.Entry<T>(model);
            entityEntry.State = EntityState.Unchanged;
            foreach (string s in proName)
            {
                entityEntry.Property(s).IsModified = true;
            }



            db.Entry<T>(model).State = EntityState.Modified;
            //return db.SaveChanges();
        }

        public void Modify(T model)
        {

            //DbEntityEntry<T> entityEntry = db.Entry<T>(model);
            //entityEntry.State = EntityState.Unchanged;


            db.Set<T>().Attach(model);

            db.Entry<T>(model).State = EntityState.Modified;
            //return db.SaveChanges();
        }


        public List<T> GetList()
        {
            return db.Set<T>().ToList<T>();
        }


        public List<T> GetListNoTracking()
        {
            return db.Set<T>().AsNoTracking<T>().ToList<T>();
        }


        public int save()
        {
            return db.SaveChanges();
        }
    }
}
