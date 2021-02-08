using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace COMP2001_API.Models
{
    public partial class COMP2001_SSerjeantContext : DbContext
    {
        public COMP2001_SSerjeantContext()
        {
        }

        public COMP2001_SSerjeantContext(DbContextOptions<COMP2001_SSerjeantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProjectPassword> ProjectPasswords { get; set; }
        public virtual DbSet<ProjectSession> ProjectSessions { get; set; }
        public virtual DbSet<ProjectUser> ProjectUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=COMP2001_SSerjeant;User Id=SSerjeant;Password=ZouQ516+");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<ProjectPassword>(entity =>
            {
                entity.HasKey(e => e.PasswordId)
                    .HasName("PK__Project___EA7BF0E8BAA03908");

                entity.ToTable("Project_Passwords");

                entity.Property(e => e.PasswordId).HasColumnName("PasswordID");

                entity.Property(e => e.PasswordDateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("Password_DateChanged");

                entity.Property(e => e.PasswordNew)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Password_New");

                entity.Property(e => e.PasswordPrevious)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Password_Previous");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjectPasswords)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_password");
            });

            modelBuilder.Entity<ProjectSession>(entity =>
            {
                entity.HasKey(e => e.SessionId)
                    .HasName("PK__Project___C9F492706FD8CF97");

                entity.ToTable("Project_Sessions");

                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.Property(e => e.SessionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Session_Date");

                entity.Property(e => e.SessionStatus).HasColumnName("Session_Status");

                entity.Property(e => e.SessionToken)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Session_Token");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjectSessions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_Session");
            });

            modelBuilder.Entity<ProjectUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Project___1788CCAC6CAB121D");

                entity.ToTable("Project_Users");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_Email");

                entity.Property(e => e.UserFirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("User_FirstName");

                entity.Property(e => e.UserSurname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("User_Surname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
