using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WebApi.Data.models;

namespace WebApi.Data.configs
{
    public class pointing_config : EntityTypeConfiguration<pointing>
    {
        public pointing_config()
        {
            HasKey(t => t.id);

            Property(t => t.id)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            ToTable("pointing");

            HasRequired(t => t.account)
                .WithMany(t => t.notes)
                .HasForeignKey(t => t.id_account);

        }
    }
}