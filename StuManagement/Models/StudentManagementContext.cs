using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StuManagement.Models
{
    public partial class StudentManagementContext : IdentityDbContext    
    {
        public StudentManagementContext()
        {
        }

        public StudentManagementContext(DbContextOptions<StudentManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<ListEvent> ListEvents { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<SchoolYear> SchoolYears { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<UserSchoolYear> UserSchoolYears { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=h-aitd202003005;Initial Catalog=StudentManagement;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Japanese_CI_AS");
            SeedingAspNetUser(modelBuilder);
            SeedingAspNetRole(modelBuilder);
            SeedingAspNetUserRole(modelBuilder);
            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Act).HasMaxLength(250);

                entity.Property(e => e.Activities).HasMaxLength(250);

                entity.Property(e => e.PowerDev).HasMaxLength(250);

                entity.Property(e => e.PowerExerted).HasMaxLength(250);

                entity.Property(e => e.SchoolYear).HasMaxLength(250);

                entity.Property(e => e.Think)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.ListEventsNavigation)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.ListEvents)
                    .HasConstraintName("FK_Events_ListEvents");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Events_Users");
            });

            modelBuilder.Entity<ListEvent>(entity =>
            {
                entity.Property(e => e.Icon).HasMaxLength(250);

                entity.Property(e => e.ListEventName).HasMaxLength(250);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.MessagesId);

                entity.Property(e => e.Content).HasMaxLength(500);

                entity.Property(e => e.Timestamp).HasColumnType("date");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_Messages_Events");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Messages_Users");
            });

            modelBuilder.Entity<SchoolYear>(entity =>
            {
                entity.Property(e => e.SchoolYearName).HasMaxLength(250);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.SkillName).HasMaxLength(250);

                entity.Property(e => e.Style).HasMaxLength(250);

                entity.Property(e => e.Tags).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Avatar).HasMaxLength(250);

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.LastLogin).HasColumnType("date");

                entity.Property(e => e.Password).HasMaxLength(250);

                entity.Property(e => e.Phone).HasMaxLength(250);

                entity.Property(e => e.StudentCode).HasMaxLength(250);

                entity.Property(e => e.UserName).HasMaxLength(250);
            });

            modelBuilder.Entity<UserSchoolYear>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ScholYearId })
                    .HasName("PK_UserSchoolYears_1");

                entity.HasOne(d => d.ScholYear)
                    .WithMany(p => p.UserSchoolYears)
                    .HasForeignKey(d => d.ScholYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSchoolYears_SchoolYears");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSchoolYears)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSchoolYears_Users");
            });

            modelBuilder.Entity<UserSkill>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.SkillId })
                    .HasName("PK_UserSkills_1");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSkills_Skills");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSkills_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private void SeedingAspNetUser(ModelBuilder modelBuilder)
        {
            User user = new User()
            {
                Id = "2c0fca4e-9376-4a70-bcc6-35bebe497866",
                UserName = "Student",
                Email = "student@gmail.com",
                NormalizedEmail = "student@gmail.com",
                NormalizedUserName = "student@gmail.com",
                LockoutEnabled = false,
                Avatar = "/images/icons/avatar4.png"
            };
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            var passwordHash = passwordHasher.HashPassword(user, "Asdf1234!");
            user.PasswordHash = passwordHash;

            modelBuilder.Entity<User>().HasData(user);
        }
        private void SeedingAspNetRole(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = "c0c6661b-0964-4e62-8083-3cac6a6741ec",
                    Name = "Student",
                    NormalizedName = "Student",
                    ConcurrencyStamp = "1"
                },
                new IdentityRole()
                {
                    Id = "32ffd287-205f-43a2-9f0d-80sc5309fb47",
                    Name = "Family",
                    NormalizedName = "Family",
                    ConcurrencyStamp = "2"
                },
                 new IdentityRole()
                 {
                     Id = "ca6f2a10-c3bc-4a1a-b947-235974cd191b",
                     Name = "Teacher",
                     NormalizedName = "Teacher",
                     ConcurrencyStamp = "3"
                 }, new IdentityRole()
                 {
                     Id = "83e8db1d-72b7-4313-b287-0e937f4af852",
                     Name = "Doctor",
                     NormalizedName = "Doctor",
                     ConcurrencyStamp = "4"
                 });
        }
        private void SeedingAspNetUserRole(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "c0c6661b-0964-4e62-8083-3cac6a6741ec",
                    UserId = "2c0fca4e-9376-4a70-bcc6-35bebe497866"
                });
        }
    }
}
