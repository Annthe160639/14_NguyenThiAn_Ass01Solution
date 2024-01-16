using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();

        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }

            }
        }

        public IEnumerable<Order> List()
        {
            List<Order> orders = new List<Order>();
            try
            {
                using (var fstoreDB = new FStore_14_NguyenThiAnContext())
                {
                    orders = fstoreDB.Orders.ToList().OrderByDescending(order => order.OrderId).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return orders;
        }


        public Order FindOne(Expression<Func<Order, bool>> predicate)
        {
            Order order = null;
            try
            {
                using (var fstoreDB = new FStore_14_NguyenThiAnContext())
                {
                    order = fstoreDB.Orders.SingleOrDefault(predicate);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return order;
        }

        public IEnumerable<Order> FindAll(Expression<Func<Order, bool>> predicate)
        {
            List<Order> orders = new List<Order>();
            using (var fstoreDB = new FStore_14_NguyenThiAnContext())
            {
                orders = fstoreDB.Orders.Where(predicate).ToList();
            }
            return orders;
        }

        public void Add(Order order)
        {
            try
            {
                Order p = FindOne(item => item.OrderId.Equals(order.OrderId));
                if (p == null)
                {
                    using (var fstoreDB = new FStore_14_NguyenThiAnContext())
                    {
                        fstoreDB.Orders.Add(order);
                        fstoreDB.SaveChanges();
                    }

                }
                else
                {
                    throw new Exception("The order is already exist");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(Order order)
        {
            try
            {
                Order p = FindOne(item => item.OrderId.Equals(order.OrderId));
                if (p != null)
                {
                    using (var fstoreDB = new FStore_14_NguyenThiAnContext())
                    {
                        fstoreDB.Orders.Remove(order);
                        fstoreDB.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The order does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Order order)
        {
            try
            {
                Order p = FindOne(item => item.OrderId.Equals(order.OrderId));
                if (p != null)
                {
                    using (var fstoreDB = new FStore_14_NguyenThiAnContext())
                    {
                        fstoreDB.Entry<Order>(order).State = EntityState.Modified;
                        fstoreDB.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The order does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
