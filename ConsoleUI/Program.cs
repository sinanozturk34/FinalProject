﻿using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            //foreach = GetAllByCategoryId(2)
            foreach (var product in productManager.GetByUnitPrice(50, 100))
                                                                           
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
    }

