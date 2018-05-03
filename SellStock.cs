using System;
namespace TP_Command_Pattern
{
    public class SellStock : Order
    {
        public SellStock()
        {
        }
        private Stock zerStock;

        public SellStock(Stock zerStock)
        {
            this.zerStock = zerStock;
        }

        public void execute()
        {
            zerStock.sell();
        }
    
    }
}
