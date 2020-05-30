using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderWinform
{
    public partial class Form1 : Form
    {
        private List<Order> orders=new List<Order>();

        public Form1()
        {
            List<OrderItem> orderItems1 = new List<OrderItem>();
            orderItems1.Add(new OrderItem("胡椒", 25.8, 10));
            orderItems1.Add(new OrderItem("牛奶", 15.8, 12));
            orderItems1.Add(new OrderItem("炸鸡", 44.2, 8));

            List<OrderItem> orderItems2 = new List<OrderItem>();
            orderItems2.Add(new OrderItem("土豆", 25.8, 10));
            orderItems2.Add(new OrderItem("番茄", 15.8, 12));
            orderItems2.Add(new OrderItem("黑人", 44.2, 8));

            List<OrderItem> orderItems3 = new List<OrderItem>();
            orderItems3.Add(new OrderItem("手机", 25.8, 10));
            orderItems3.Add(new OrderItem("电脑", 15.8, 12));
            orderItems3.Add(new OrderItem("平板", 44.2, 8));

            List<OrderItem> orderItems4 = new List<OrderItem>();
            orderItems4.Add(new OrderItem("a", 5.8, 10));
            orderItems4.Add(new OrderItem("b", 5.8, 12));
            orderItems4.Add(new OrderItem("c", 4.2, 8));

            Order order1 = new Order("Trump", orderItems1, "898");

            Order order2 = new Order("Donald", orderItems2, "787");

            Order order3 = new Order("Jobs", orderItems3, "999");

            Order order4 = new Order("Jobs", orderItems4, "323");

            this.orders.Add(order1);
            this.orders.Add(order2);
            this.orders.Add(order3);
            this.orders.Add(order4);

            InitializeComponent();
            bindingSource2.Add(order1);
            bindingSource2.Add(order2);
            bindingSource2.Add(order3);
            bindingSource2.Add(order4);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String id = textBox1.Text;
            OrderService service = new OrderService(this.orders);
            IOrderedEnumerable<Order> results= service.query(id);
           // service.queryByName(id);
           // Console.Write("wocao");
            bindingSource2.Clear();
            foreach(Order order in results)
            {
                bindingSource2.Add(order);
            }
           

        }
    }
}
