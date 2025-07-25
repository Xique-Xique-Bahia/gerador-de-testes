﻿// <auto-generated />
using System;
using Gerador_de_testes.Infraestrutura.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gerador_de_testes.Infraestrutura.Orm.Migrations
{
    [DbContext(typeof(GeradorDeTestesDbContext))]
    [Migration("20250720234529_Add_TBTeste")]
    partial class Add_TBTeste
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Gerador_de_testes.ModuloDeTestes.Teste", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("QteQuestoes")
                        .HasColumnType("integer");

                    b.Property<string>("Serie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Testes");
                });

            modelBuilder.Entity("Gerador_de_testes.ModuloDisciplina.Disciplina", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid?>("TesteId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TesteId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("Gerador_de_testes.ModuloMateria.Materia", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DisciplinaId")
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Serie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("Gerador_de_testes.ModuloQuestao.Alternativa", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Correta")
                        .HasColumnType("boolean");

                    b.Property<Guid>("QuestaoId")
                        .HasColumnType("uuid");

                    b.Property<string>("Resposta")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("Id");

                    b.HasIndex("QuestaoId");

                    b.ToTable("Alternativa");
                });

            modelBuilder.Entity("Gerador_de_testes.ModuloQuestao.Questao", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Enunciado")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<Guid>("MateriaId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MateriaId");

                    b.ToTable("Questoes");
                });

            modelBuilder.Entity("MateriaTeste", b =>
                {
                    b.Property<Guid>("MateriasId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TesteId")
                        .HasColumnType("uuid");

                    b.HasKey("MateriasId", "TesteId");

                    b.HasIndex("TesteId");

                    b.ToTable("MateriaTeste");
                });

            modelBuilder.Entity("QuestaoTeste", b =>
                {
                    b.Property<Guid>("QuestoesSelecionadasId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TesteId")
                        .HasColumnType("uuid");

                    b.HasKey("QuestoesSelecionadasId", "TesteId");

                    b.HasIndex("TesteId");

                    b.ToTable("QuestaoTeste");
                });

            modelBuilder.Entity("Gerador_de_testes.ModuloDisciplina.Disciplina", b =>
                {
                    b.HasOne("Gerador_de_testes.ModuloDeTestes.Teste", null)
                        .WithMany("Disciplinas")
                        .HasForeignKey("TesteId");
                });

            modelBuilder.Entity("Gerador_de_testes.ModuloMateria.Materia", b =>
                {
                    b.HasOne("Gerador_de_testes.ModuloDisciplina.Disciplina", "Disciplina")
                        .WithMany("Materias")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("Gerador_de_testes.ModuloQuestao.Alternativa", b =>
                {
                    b.HasOne("Gerador_de_testes.ModuloQuestao.Questao", "Questao")
                        .WithMany("Alternativas")
                        .HasForeignKey("QuestaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Questao");
                });

            modelBuilder.Entity("Gerador_de_testes.ModuloQuestao.Questao", b =>
                {
                    b.HasOne("Gerador_de_testes.ModuloMateria.Materia", "Materia")
                        .WithMany("Questoes")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("MateriaTeste", b =>
                {
                    b.HasOne("Gerador_de_testes.ModuloMateria.Materia", null)
                        .WithMany()
                        .HasForeignKey("MateriasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gerador_de_testes.ModuloDeTestes.Teste", null)
                        .WithMany()
                        .HasForeignKey("TesteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuestaoTeste", b =>
                {
                    b.HasOne("Gerador_de_testes.ModuloQuestao.Questao", null)
                        .WithMany()
                        .HasForeignKey("QuestoesSelecionadasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gerador_de_testes.ModuloDeTestes.Teste", null)
                        .WithMany()
                        .HasForeignKey("TesteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gerador_de_testes.ModuloDeTestes.Teste", b =>
                {
                    b.Navigation("Disciplinas");
                });

            modelBuilder.Entity("Gerador_de_testes.ModuloDisciplina.Disciplina", b =>
                {
                    b.Navigation("Materias");
                });

            modelBuilder.Entity("Gerador_de_testes.ModuloMateria.Materia", b =>
                {
                    b.Navigation("Questoes");
                });

            modelBuilder.Entity("Gerador_de_testes.ModuloQuestao.Questao", b =>
                {
                    b.Navigation("Alternativas");
                });
#pragma warning restore 612, 618
        }
    }
}
