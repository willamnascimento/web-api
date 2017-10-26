using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WebApi.Data.Models;

namespace WebApi.Data.configs
{
    public class account_config : EntityTypeConfiguration<account>
    {
        public account_config()
        {
            HasKey(t => t.id);

            this.Property(t => t.id)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("account");
        }
    }
}