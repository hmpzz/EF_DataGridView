using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Model
{
    public class Order
    {


        
        public int id { get; set; }


        


        
        public string order_no { get; set; }


        
        
        public string name { get; set; }

        

        public DateTime? CreateDate { get; set; }

        
    }



    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            //定义主键
            this.HasKey(t => new {t.order_no});

            //
            Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.order_no).HasMaxLength(50).IsRequired();

            
            //HasKey(x => x.Id);
            //Property(x => x.Name).HasMaxLength(50).IsRequired();
            //HasMany(x => x.Users)
            //    .WithMany(x => x.Roles)
            //    .Map(m =>
            //    {
            //        m.MapLeftKey("RoleId");
            //        m.MapRightKey("UserId");
            //        m.ToTable("LNK_User_Role");
            //    });

        }
    }
}
