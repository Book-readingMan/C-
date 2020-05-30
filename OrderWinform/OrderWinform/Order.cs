using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * 我先把周五的课堂作业贴出来。作业的代码量比较大一点，大家提前做好准备。
   写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询）功能。
提示：主要的类有Order（订单）、OrderItem（订单明细项），OrderService（订单服务），订单数据可以保存在OrderService中一个List中。在Program里面可以调用OrderService的方法完成各种订单操作。
要求：
（1）使用LINQ语言实现各种查询功能，查询结果按照订单总金额排序返回。
（2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
（3）作业的订单和订单明细类需要重写Equals方法，确保添加的订单不重复，每个订单的订单明细不重复。
（4）订单、订单明细、客户、货物等类添加ToString方法，用来显示订单信息。
（5）OrderService提供排序方法对保存的订单进行排序。默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。
*/
namespace OrderWinform
{
   public class Order
    {
        public String Customer { get; set; }
        public String OrderNumber { get; set; }
        public DateTime DateTime { get; set; }
        public double TotalCost { get; set; }

        public List<OrderItem> items { get;set; }


        //order构造函数
        public Order(String name,List<OrderItem> items,String orderNumber)
        {
            this.items=items;
            this.Customer = name;
            this.DateTime = DateTime.Now;
            this.OrderNumber = orderNumber;
            var query = items.Where(x => true);

            this.TotalCost = query.Sum(i => i.Price);
        }

        public override bool Equals(object obj)
        {
            Order order = obj as Order;
            return order != null && order.OrderNumber == this.OrderNumber;
        }

        public override string ToString()
        {
            StringBuilder item = new StringBuilder();
            foreach(OrderItem x in items)
            {
                item.Append(x.ToString());
            }
            return "Customer:" + this.Customer + "\n" + "Datetime" + this.DateTime + "\n" + "OrderNumber:" +
                this.OrderNumber + "\n" + item+"TotalCost:"+this.TotalCost;
        }


    }

   public class OrderItem
    {
        public String ProductName { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }

        public OrderItem(String product,double price,int amount)
        {
            this.Amount = amount;
            this.Price = price;
            this.ProductName = product;
        }

        public override bool Equals(object obj)
        {
            OrderItem item = obj as OrderItem;
            return item != null && item.ProductName == this.ProductName&&this.Price==item.Price&&
                this.Amount==item.Amount;
        }

        public override string ToString()
        {
            return "ProductName:" + this.ProductName + "\n" + "Price:" + this.Price + "\n"
                + "Amount:" + this.Amount+"\n";
        }

    }
  public  class RepeatException:Exception
    {
        private String error = "添加失败！订单已存在";
        public RepeatException()
        {
            Console.WriteLine(error);
        }
    }

   public class OrderService
    {
        List<Order> orders = new List<Order>();

        public OrderService(List<Order> orders)
        {
            this.orders = orders;
        }

        public void addOrder(Order order)
        {
            try
            {
                foreach (Order x in orders)
                {
                    if (order.Equals(x))
                    {
                        throw new RepeatException();
                    }
                }
                orders.Add(order);
            }catch(RepeatException e)
            {
                Console.WriteLine(e.ToString());
            }
           
        }

        public void deleteOrder(String number)
        {
            foreach(Order x in orders)
            {
                if(number.Equals(x.OrderNumber))
                {
                    orders.Remove(x);
                }
                else
                {
                    Console.WriteLine("删除订单失败！没有找到订单：" + number);
                }
            }
        }

        public void queryByNumber(String number)
        {
            var results = from order in orders
                          where order.OrderNumber == number
                          orderby order.TotalCost
                          select order;
            StringBuilder res = new StringBuilder();

            foreach(Order order in results)
            {
                res.Append(order.ToString());
            }
            Console.WriteLine(res);

        }

        public IOrderedEnumerable<Order> query(String name)
        {
            var results = from order in orders
                          where order.Customer == name
                          orderby order.TotalCost
                          select order;
            return results;
        }

        public void queryByName(String name)
        {
            var results = from order in orders
                          where order.Customer == name
                          orderby order.TotalCost
                          select order;

            StringBuilder res = new StringBuilder();

            foreach (Order order in results)
            {
                res.Append(order.ToString());
            }
            Console.WriteLine(res);

        }

        public void queryByProduct(String Product)
        {

        }

        public void sortOrders()
        {
            var results = from order in orders
                          where true
                          orderby order.OrderNumber
                          select order;
            this.orders = results.ToList();
        }

        public void sortOrdersByCustomer()
        {
            var results = orders.Where(order => true).OrderBy(order => order.Customer);
            this.orders = results.ToList();
        }

        public void showOrders()
        {
            foreach(Order x in orders)
            {
                Console.WriteLine(x.ToString());
            }
        }


    }
}
