using System.ComponentModel.DataAnnotations;

namespace project_final_6013532{

    public class ClientData {

        [Key]        
        public string clientDataId {get;set;}
        public string name {get;set;}
        public string surname {get;set;}
        public string mktId {get;set;}
        public string mktName {get;set;}
        public string telNo {get;set;}
            


    }//end of class RejectAts
}//end of namespace