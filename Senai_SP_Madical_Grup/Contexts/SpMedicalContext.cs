using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Senai_SP_Madical_Grup.Domains;

#nullable disable

namespace Senai_SP_Madical_Grup.Contexts
{
    public partial class SpMedicalContext : DbContext
    {
        public SpMedicalContext()
        {
        }

        public SpMedicalContext(DbContextOptions<SpMedicalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Consultum> Consulta { get; set; }
        public virtual DbSet<Especializacao> Especializacaos { get; set; }
        public virtual DbSet<Instituicao> Instituicaos { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NOTE0113H2\\SQLEXPRESS; initial catalog=SP_MADICAL_GRUP_Fe; user id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Consultum>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__consulta__CA9C61F5DB31CEB5");

                entity.ToTable("consulta");

                entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");

                entity.Property(e => e.DataConsulta)
                    .HasColumnType("date")
                    .HasColumnName("dataConsulta");

                entity.Property(e => e.DescricaoConsulta)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descricaoConsulta");

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__consulta__idMedi__3C69FB99");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK__consulta__idPaci__3E52440B");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__consulta__idSitu__3D5E1FD2");
            });

            modelBuilder.Entity<Especializacao>(entity =>
            {
                entity.HasKey(e => e.IdEspecializacao)
                    .HasName("PK__especial__FC35476C81323492");

                entity.ToTable("especializacao");

                entity.Property(e => e.IdEspecializacao).HasColumnName("idEspecializacao");

                entity.Property(e => e.TipoEspecializacao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipoEspecializacao");
            });

            modelBuilder.Entity<Instituicao>(entity =>
            {
                entity.HasKey(e => e.IdIstituição)
                    .HasName("PK__institui__E58A0FE15425097D");

                entity.ToTable("instituicao");

                entity.HasIndex(e => e.Cnpj, "UQ__institui__AA57D6B4694125C7")
                    .IsUnique();

                entity.Property(e => e.IdIstituição).HasColumnName("idIstituição");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.NomeInstuicao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeInstuicao");

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("razaoSocial");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__medico__4E03DEBA41DF229D");

                entity.ToTable("medico");

                entity.HasIndex(e => e.Crm, "UQ__medico__D836F7D187FBCE35")
                    .IsUnique();

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("crm");

                entity.Property(e => e.IdEspecializacao).HasColumnName("idEspecializacao");

                entity.Property(e => e.IdInstituicao).HasColumnName("idInstituicao");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdEspecializacaoNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecializacao)
                    .HasConstraintName("FK__medico__idEspeci__38996AB5");

                entity.HasOne(d => d.IdInstituicaoNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdInstituicao)
                    .HasConstraintName("FK__medico__idInstit__398D8EEE");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__medico__idUsuari__37A5467C");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__paciente__F48A08F2CF0D8892");

                entity.ToTable("paciente");

                entity.HasIndex(e => e.Rg, "UQ__paciente__321537C8B6A64C0A")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__paciente__C1F89731BC1FA51C")
                    .IsUnique();

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.DataNasc)
                    .HasColumnType("datetime")
                    .HasColumnName("dataNasc");

                entity.Property(e => e.EnderecoPaciente)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("enderecoPaciente");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("RG");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__paciente__idUsua__33D4B598");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__situacao__12AFD197781342FA");

                entity.ToTable("situacao");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFFFF388B1D");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.TituloTipoUsuario, "UQ__tipoUsua__C6B29FC3EFA4F748")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoUsuario");

                entity.Property(e => e.TituloTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tituloTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A6B40580AB");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.EmailUsuario, "UQ__usuario__ACC1DD9983B6303A")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.EmailUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("emailUsuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.SenhaUsuario)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("senhaUsuario");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuario__idTipoU__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
