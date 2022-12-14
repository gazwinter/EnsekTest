// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.EntityFrameworkCore;

namespace EnsekTest.Data.Entities
{
    public partial class EnsekTestContext : DbContext
    {
        public EnsekTestContext()
        {
        }

        public EnsekTestContext(DbContextOptions<EnsekTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<MeterReadings> MeterReadings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__Accounts__349DA5A63181EBD7");

                entity.Property(e => e.AccountId).ValueGeneratedOnAdd();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasData(SeedAccount());
            });

            modelBuilder.Entity<MeterReadings>(entity =>
            {
                entity.HasKey(e => e.MeterReadingId)
                    .HasName("PK__MeterRea__AFB4FD9945351D10");

                entity.Property(e => e.MeterReadingId).ValueGeneratedOnAdd();

                entity.Property(e => e.MeterReadingDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.MeterReadings)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeterReadings_Accounts");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=EnsekTest;MultipleActiveResultSets=true;TrustServerCertificate=true");
        }

        private IEnumerable<Accounts> SeedAccount()
        {
            return new List<Accounts>
            {
                new Accounts
                {
                    AccountId = 2344,
                    FirstName = "Tommy",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 2233,
                    FirstName = "Barry",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 8766,
                    FirstName = "Sally",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 2345,
                    FirstName = "Jerry",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 2346,
                    FirstName = "Ollie",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 2347,
                    FirstName = "Tara",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 2348,
                    FirstName = "Tammy",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 2349,
                    FirstName = "Simon",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 2350,
                    FirstName = "Colin",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 2351,
                    FirstName = "Gladys",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 2352,
                    FirstName = "Greg",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 2353,
                    FirstName = "Tony",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 2355,
                    FirstName = "Arthur",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 2356,
                    FirstName = "Craig",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 6776,
                    FirstName = "Laura",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 4534,
                    FirstName = "JOSH",
                    LastName = "TEST"
                },
                new Accounts
                {
                    AccountId = 1234,
                    FirstName = "Freya",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 1239,
                    FirstName = "Noddy",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 1240,
                    FirstName = "Archie",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 1241,
                    FirstName = "Lara",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 1242,
                    FirstName = "Tim",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 1243,
                    FirstName = "Graham",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 1244,
                    FirstName = "Tony",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 1245,
                    FirstName = "Neville",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 1246,
                    FirstName = "Jo",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 1247,
                    FirstName = "Jim",
                    LastName = "Test"
                },
                new Accounts
                {
                    AccountId = 1248,
                    FirstName = "Pam",
                    LastName = "Test"
                },
            };
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}