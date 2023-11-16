using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BDS.Models
{
    public partial class BDSContext : DbContext
    {
        public BDSContext()
        {
        }

        public BDSContext(DbContextOptions<BDSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Donor> Donors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = BDS; Trusted_Connection = True; ");
            }
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

			modelBuilder.Entity<Admin>(entity =>
			{
				entity.ToTable("admin");

				entity.Property(e => e.Password)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("password");

				entity.Property(e => e.Username)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("username");
			});

			modelBuilder.Entity<Donor>(entity =>
			{
				entity.ToTable("donor");

				entity.Property(e => e.Age).HasColumnName("age");

				entity.Property(e => e.Bloodtype)
					.IsRequired()
					.HasMaxLength(50)
					.HasColumnName("bloodtype");

				entity.Property(e => e.Email)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("email");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("name");

				entity.Property(e => e.Phno)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("phno");

				entity.Property(e => e.Residence)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("residence");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		//partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


	}
}
