using System.ComponentModel.DataAnnotations;

namespace project_final_6013532{

    public class RejectAts {
        
        [Key]
        public int rejectAtsId {get;set;}
        public string refCode {get;set;}  
           
        public string clientDataId {get;set;} 
        public ClientData client {get;set;}
        public string sendingBank {get;set;}
        public string sendingBankNo {get;set;}
        public string receivingBank {get;set;}
        public string receivingBankNo {get;set;}
        public double amount {get;set;}
        public string statusCode {get;set;}
        public string statusDescription {get;set;}       


    }//end of class RejectAts
}//end of namespace