using System;
using System.Collections.Generic;
namespace TP_Command_Pattern
{
    public class Broker
    {
        public Broker()
        {
        }
        private List<Order> orderList = new List<Order>();

        public void takeOrder(Order order)
        {
            orderList.Add(order);
        }

        public void placeOrder()
        {
            foreach (Order order in orderList)
            {
                order.execute();
            }
            orderList.Clear();
        }
    }
}
