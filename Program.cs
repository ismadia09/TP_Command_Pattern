using System;

namespace TP_Command_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Stock zerStock = new Stock();
            BuyStock buyStock = new BuyStock(zerStock);
            SellStock sellStock = new SellStock(zerStock);



            Stock stockos = new Stock(1, "92 injections", 92);
            BuyStock buyStockZer = new BuyStock(stockos);
            SellStock sellStockZer = new SellStock(stockos);
            DeleteItemStock deleteItem = new DeleteItemStock(stockos);

            Broker broker = new Broker();
            broker.takeOrder(buyStock);
            broker.takeOrder(sellStock);
            broker.takeOrder(buyStockZer);
            broker.takeOrder(sellStockZer);


            broker.placeOrder();

            DBConnection.GetInstance().printStocks();

            DeleteItemStock delete = new DeleteItemStock(stockos);
            broker.takeOrder(delete);
            broker.placeOrder();

            DBConnection.GetInstance().printStocks();

        }
    }
}
