using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;

namespace ConsoleUI
{
     class Program
    {
         static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();
            //DTO:Data Transformation Object

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);

            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetProductDetails())
            {//GetByUnitPrice(40, 100),CategoryId
                Console.WriteLine(product.ProductName+"/"+product.CategoryName);
            }
        }
    }
    }

