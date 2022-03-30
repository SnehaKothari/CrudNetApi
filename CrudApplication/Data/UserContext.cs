using LinqToDB.SchemaProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using user.Web.Models;
using user.Web.Repository;
using user.Web.Data;

namespace user.Web.Data
{
    public class UserContext:DbContext
    {

        /* private readonly TABLECONFIGURATION _tableConf;


         public UserContext(DbContextOptions<UserContext> options,IOptions<TABLECONFIGURATION> tableConf) : base(options)
         {
             _tableConf = (TABLECONFIGURATION)tableConf;
         }

         public UserContext(DbContextOptions<UserContext> options, string schema) : base(options)
         {
             _tableConf = new TABLECONFIGURATION();
             {
                 DATABASESCHEMA = schema;
             };
         }

         public string DATABASESCHEMA { get; }*/

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<Users> users { get; set; }
    }

}
