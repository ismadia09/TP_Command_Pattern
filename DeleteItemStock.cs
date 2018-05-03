using System;
namespace TP_Command_Pattern
{
    public class DeleteItemStock : Order
    {
        public DeleteItemStock()
        {
        }
        private Stock zerStock;

        public DeleteItemStock(Stock zerStock)
        {
            this.zerStock = zerStock;
        }

        public void execute()
        {
            zerStock.delete();
        }
    
    }
}
