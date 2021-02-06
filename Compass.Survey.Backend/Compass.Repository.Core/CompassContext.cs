using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compass.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Compass.Repository.Core
{
    public class CompassContext : DbContext
    {
        private static CompassContext instance = null;
        //public sealed class Singleton
        //{
        //    private static Singleton instance = null;

        //    private Singleton()
        //    {
        //    }

        //    public static Singleton Instance
        //    {
        //        get
        //        {
        //            if (instance == null)
        //            {
        //                instance = new Singleton();
        //            }
        //            return instance;
        //        }
        //    }
        //}

        public CompassContext() : base(GetOptions("DefaultConnection"))
        { }

        //public CompassContext(DbContextOptions<CompassContext> options)
        //: base(options)
        //{ }

        private static DbContextOptions GetOptions(string connectionString)
        {
            var options = SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
            return options;
        }

        public CompassContext(DbContextOptions<CompassContext> options) : base(options)
        {
        }

        public static CompassContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CompassContext();
                }
                return instance;
            }
        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            //     => options.UseSqlServer("Data Source=DESKTOP-05US5NA;Initial Catalog=test-1;Integrated Security=True");

        }

        //public DbSet<Survey> Surveys { get; set; }
        //public DbSet<Question> Quesions { get; set; }
        //public DbSet<Option> Options { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    new SurverEntityTypeConfiguration().Configure(modelBuilder.Entity<Survey>());
        //    new QuestionEntityTypeConfiguration().Configure(modelBuilder.Entity<Question>());
        //    //modelBuilder.Configurations.Add(new SurveyConfiguration());
        //    //modelBuilder.Configurations.Add(new QuestionConfiguration());
        //    base.OnModelCreating(modelBuilder);
        //}

        //public static ModelBuilder CreateModel(ModelBuilder modelBuilder, string schema)
        //{
        //    new SurverEntityTypeConfiguration().Configure(modelBuilder.Entity<Survey>());
        //    new QuestionEntityTypeConfiguration().Configure(modelBuilder.Entity<Question>());
        //    return modelBuilder;
        //}
        //public class SurverEntityTypeConfiguration : IEntityTypeConfiguration<Survey>
        //{
        //    public void Configure(EntityTypeBuilder<Survey> builder)
        //    {
        //        builder.ToTable("Survey");
        //        builder.HasKey(x => x.Id);

        //        builder.Property(x => x.Id).IsRequired();
        //        builder.Property(x => x.Name).IsRequired().IsUnicode(true).HasMaxLength(100);
        //    }
        //}
        //public class QuestionEntityTypeConfiguration : IEntityTypeConfiguration<Question>
        //{
        //    public void Configure(EntityTypeBuilder<Question> builder)
        //    {
        //        builder.ToTable("Question");
        //        builder.HasKey(x => x.Id);

        //        builder.Property(x => x.Id).IsRequired();
        //        builder.Property(x => x.createdBy).IsRequired().IsUnicode(true).HasMaxLength(100);
        //        builder.Property(x => x.Title).IsRequired().IsUnicode(true).HasMaxLength(100);
        //        builder.HasOne(x => x.Survey).WithMany(x => x.Questions);

        //    }
        //}

        //public class OptionEntityTypeConfiguration : IEntityTypeConfiguration<Option>
        //{
        //    public void Configure(EntityTypeBuilder<Option> builder)
        //    {
        //        builder.ToTable("Option");
        //        builder.HasKey(x => x.Id);

        //        builder.Property(x => x.Id).IsRequired();
        //        builder.Property(x => x.Text).IsRequired().IsUnicode(true).HasMaxLength(100);
        //        builder.HasOne(x => x.Question).WithMany(x => x.Options);

        //    }
        //}

    }
}
