namespace MarketPlace.Models{

    public class User {

        public string UserName {get;set;}
        public string FirstName {get;set;}
         public string LastName {get;set;}
        public string Email{get;set;}
        public string Password {get;set;}
        public string CreditCardInfo_CardNumber {get;set;}

        public override string ToString(){
         return $"({UserName}, {FirstName}, {LastName}, {Email}, {Password}, {CreditCardInfo_CardNumber}\n";
        }


    }

}
  