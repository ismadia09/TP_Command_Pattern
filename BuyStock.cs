using System;
namespace TP_Command_Pattern
{
    public class BuyStock : Order
    {
        public BuyStock()
        {
        }

        private Stock zerStock;

        public BuyStock(Stock zerStock){
            this.zerStock = zerStock;
        }

        public void execute(){
            zerStock.buy();
        }

        public void unexecute(){
            zerStock.sell();
        }
    }
}
