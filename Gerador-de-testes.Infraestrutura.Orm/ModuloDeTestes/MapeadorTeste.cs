﻿using Gerador_de_testes.ModuloDeTestes;
using Gerador_de_testes.ModuloMateria;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gerador_de_testes.Infraestrutura.Orm.ModuloDeTestes
{
    public class MapeadorTeste : IEntityTypeConfiguration<Teste>
    {
        public void Configure(EntityTypeBuilder<Teste> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.Titulo)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Serie)
                .HasMaxLength(50)
                .IsRequired();

            // Ajuste: Relacionamento correto com Materia
            builder.HasMany(x => x.Materias)
                .WithMany();
          
            builder.Property(x => x.QteQuestoes)
                .IsRequired();
        }
    }
}
