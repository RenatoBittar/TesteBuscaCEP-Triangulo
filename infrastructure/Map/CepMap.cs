using Infrastructure.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Infrastructure.Map
{
    class CepMap : EntityTypeConfiguration<CEP>
    {
        public CepMap()
        {
            this.ToTable("CEP");
            this.HasKey(c => c.Id);
            this.Property(c => c.cep)
                .HasColumnName("cep")
                .HasColumnType("CHAR")
                .HasMaxLength(9);

            this.Property(c => c.logradouro)
                .HasColumnName("logradouro")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

            this.Property(c => c.complemento)
                .HasColumnName("complemento")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

            this.Property(c => c.bairro)
                .HasColumnName("bairro")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

            this.Property(c => c.localidade)
                .HasColumnName("localidade")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

            this.Property(c => c.uf)
                .HasColumnName("uf")
                .HasColumnType("CHAR")
                .HasMaxLength(2);

            this.Property(c => c.unidade)
                .HasColumnName("unidade")
                .HasColumnType("BIGINT");

            this.Property(c => c.ibge)
                .HasColumnName("ibge")
                .HasColumnType("INT");

            this.Property(c => c.gia)
                .HasColumnName("gia")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

            //CREATE TABLE [dbo].[CEP] (
            //    [Id]          INT            IDENTITY (1, 1) NOT NULL,
            //    [cep]         CHAR (9)       NULL,
            //    [logradouro]  NVARCHAR (500) NULL,
            //    [complemento] NVARCHAR (500) NULL,
            //    [bairro]      NVARCHAR (500) NULL,
            //    [localidade]  NVARCHAR (500) NULL,
            //    [uf]          CHAR (2)       NULL,
            //    [unidade]     BIGINT         NULL,
            //    [ibge]        INT            NULL,
            //    [gia]         NVARCHAR (500) NULL
            //);

        }
    }
}
