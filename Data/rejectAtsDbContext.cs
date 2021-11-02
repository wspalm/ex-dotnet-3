using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project_final_6013532.Models;

namespace project_final_6013532.Data {
    public class rejectAtsDbContext : DbContext{
        //constructor that sub class from another class has to use options :base(options)
            public rejectAtsDbContext(DbContextOptions<rejectAtsDbContext> options):base(options){

            }//end of class

            public DbSet<RejectAts> rejectAts {get;set;}
          
            public DbSet<ClientData> clientdata {get;set;}

    
    }//end of class
}//end of namespace