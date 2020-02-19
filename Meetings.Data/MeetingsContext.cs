using System;
using Meetings.Domain;
using Microsoft.EntityFrameworkCore;

namespace Meetings.Data
{
    public class MeetingsContext : DbContext
    {
        public MeetingsContext(DbContextOptions<MeetingsContext> options) : base(options){}
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingUser> MeetingUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Meeting
            modelBuilder.Entity<Meeting>().ToTable("Meeting");
            modelBuilder.Entity<Meeting>().HasKey(x => x.Id).HasName("PK_Meeting_Id");
            modelBuilder.Entity<Meeting>().HasOne(x => x.Room).WithMany(x => x.Meetings).HasForeignKey(x => x.RoomId).HasConstraintName("FK_Meeting_Room_Id");
            modelBuilder.Entity<Meeting>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Meeting>().Property(x => x.StartDateTime).IsRequired();
            modelBuilder.Entity<Meeting>().Property(x => x.EndDateTime).IsRequired();

            // MeetingPerson
            modelBuilder.Entity<MeetingUser>().ToTable("MeetingPerson");
            modelBuilder.Entity<MeetingUser>().HasKey(x => new {x.MeetingId, x.UserId}).HasName("PK_MeetingMeeting_MeetingId_PersonId");
            modelBuilder.Entity<MeetingUser>().HasOne(x => x.Meeting).WithMany(x => x.MeetingUsers).HasForeignKey(x => x.MeetingId).HasConstraintName("FK_MeetingPerson_Meeting_Id");
            modelBuilder.Entity<MeetingUser>().HasOne(x => x.User).WithMany(x => x.MeetingUsers).HasForeignKey(x => x.UserId).HasConstraintName("FK_MeetingPerson_Person_Id");
            modelBuilder.Entity<MeetingUser>().Property(x => x.UserId).HasColumnName("PersonId");
            
            // Room
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Room>().HasKey(x => x.Id).HasName("PK_Room_Id");
            modelBuilder.Entity<Room>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Room>().Property(x => x.MaxOccupancy);
            
            // User
            modelBuilder.Entity<User>().ToTable("Person");
            modelBuilder.Entity<User>().HasKey(x => x.Id).HasName("PK_Person_Id");
            modelBuilder.Entity<User>().HasMany(x => x.MeetingUsers).WithOne(x => x.User).HasForeignKey(x => x.UserId).HasConstraintName("FK_MeetingPerson_Person_Id");
            modelBuilder.Entity<User>().Property(x => x.FirstName).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.LastName).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.AuthToken).IsRequired();

            // Seed database
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Jane",
                    LastName = "Carter",
                    AuthToken = "12345"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Doug",
                    LastName = "Johnson",
                    AuthToken = "abcdef"
                });
            modelBuilder.Entity<MeetingUser>().HasData(
                new MeetingUser
                {
                    MeetingId = 1,
                    UserId = 1
                },
                new MeetingUser
                {
                    MeetingId = 1,
                    UserId = 2
                });
            modelBuilder.Entity<Meeting>().HasData(
                new Meeting
                {
                    Id = 1,
                    StartDateTime = new DateTimeOffset(2020, 1, 15, 12, 0, 0, TimeSpan.Zero),
                    EndDateTime = new DateTimeOffset(2020, 1, 15, 13, 0, 0, TimeSpan.Zero),
                    Name = "Quarterly Sales Meeting",
                    Description = "How did we do this quarter?",
                    RoomId = 1
                });
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    MaxOccupancy = 10,
                    Name = "Mount Evans Conference Room"
                },
                new Room
                {
                    Id = 2,
                    MaxOccupancy = 8,
                    Name = "Longs Peak Conference Room"
                });
        }
    }
}