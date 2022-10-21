using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebMinimalApiNet6.Models;

namespace WebMinimalApiNet6.Data.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(160);

            builder.Property(x => x.Feito)
                .IsRequired()
                .HasColumnType("BIT");
        }
    }
}
