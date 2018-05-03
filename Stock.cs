using System;
namespace TP_Command_Pattern
{
    public class Stock
    {
        private int ID = 0;
        private String name = "test zer";
        private int quantity = 20;
        private String state = "bought";

        public Stock()
        {
        }

        public Stock(int ID, String name, int quantity){
            this.ID = ID;
            this.name = name;
            this.quantity = quantity;
           // this.state = state;

        }

        public int getID()
        {
            return ID;
        }
        public string getName(){
            return name;
        }

        public int getQuantity(){
            return quantity;
        }
        public string getState(){
            return state;
        }

        public void setName(String name){
            this.name = name;
        } 

        public void setState(String state){
            this.state = state;
        } 

        public void setState(int quantity){
            this.quantity = quantity;
        } 
        public void buy(){
            this.setState("acheté");
            DBConnection.GetInstance().Add(this);
            //Console.WriteLine("Stock [ Name: " + name + ", Quantity: " + quantity +" ] bought");
        }

        public void sell() {
            this.setState("vendu");
            DBConnection.GetInstance().Add(this);
            //Console.WriteLine("Stock [ Name: " + name + ", Quantity: " + quantity + " ] sold");
        }

        public void delete(){
            DBConnection.GetInstance().Delete(this);
        }
    }
}
