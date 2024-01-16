using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }

            }
        }

        public IEnumerable<Product> List()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (var fstoreDB = new FStore_14_NguyenThiAnContext())
                {
                    products = fstoreDB.Products.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return products;
        }

        public Product FindOne(Expression<Func<Product, bool>> predicate)
        {
            Product product = null;
            try
            {
                using (var fstoreDB = new FStore_14_NguyenThiAnContext())
                {
                    product = fstoreDB.Products.SingleOrDefault(predicate);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return product;
        }

        public IEnumerable<Product> FindAll(Expression<Func<Product, bool>> predicate)
        {
            List<Product> products = new List<Product>();
            try
            {
                using (var fstoreDB = new FStore_14_NguyenThiAnContext())
                {
                    products = fstoreDB.Products.Where(predicate).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return products;
        }

        public void Add(Product product)
        {
            try
            {
                Product p = FindOne(item => item.ProductId.Equals(product.ProductId));
                if (p == null)
                {
                    using (var fstoreDB = new FStore_14_NguyenThiAnContext())
                    {
                        fstoreDB.Products.Add(product);
                        fstoreDB.SaveChanges();
                    }

                }
                else
                {
                    throw new Exception("The product is already exist");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(Product product)
        {
            try
            {
                Product p = FindOne(item => item.ProductId.Equals(product.ProductId));
                if (p != null)
                {
                    using (var fstoreDB = new FStore_14_NguyenThiAnContext())
                    {
                        fstoreDB.Products.Remove(product);
                        fstoreDB.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The product does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Product product)
        {
            try
            {
                Product p = FindOne(item => item.ProductId.Equals(product.ProductId));
                if (p != null)
                {
                    using (var fstoreDB = new FStore_14_NguyenThiAnContext())
                    {
                        fstoreDB.Entry<Product>(product).State = EntityState.Modified;
                        fstoreDB.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The product does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

}
