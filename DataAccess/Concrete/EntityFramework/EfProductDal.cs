using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {//using içindeki nesneler işi bitince çöp toplayıcı geliyor ve beni bellekten at diyor
            using (NorthwindContext context = new NorthwindContext())
            //using tab,bunun yerine -northwindcontext- newlesekde olur
            {
                var addedEntity = context.Entry(entity);//referansı yakalama
                addedEntity.State = EntityState.Added;//eklenecek nesne
                context.SaveChanges();//ve ekle.entity framework özel ekleme 

            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            //using tab,bunun yerine -northwindcontext- newlesekde olur
            {
                var deletedEntity = context.Entry(entity);//referansı yakalama
                deletedEntity.State = EntityState.Deleted;//eklenecek nesne
                context.SaveChanges();//ve ekle.entity framework özel ekleme 

            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {//Burası tek data getircekdi.
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);//filtrele
            }//ürünler tablom,sonra filtrele
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null
                  ? context.Set<Product>().ToList()
                  : context.Set<Product>().Where(filter).ToList();
            }//null ise tümünü getir,liste çevir,degilse filtre var ise filtrele ver


        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            //using tab,bunun yerine -northwindcontext- newlesekde olur
            {//Modified=guncelleme
                var updatedEntity = context.Entry(entity);//referansı yakalama
                updatedEntity.State = EntityState.Modified;//eklenecek nesne
                context.SaveChanges();//ve ekle.entity framework özel ekleme 

            }
        }
    }
}
