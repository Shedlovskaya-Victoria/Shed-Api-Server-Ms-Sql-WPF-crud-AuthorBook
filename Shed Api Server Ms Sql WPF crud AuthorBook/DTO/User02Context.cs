using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO;

public partial class User02Context : DbContext
{
    public User02Context()
    {
    }

    public User02Context(DbContextOptions<User02Context> options)
        : base(options)
    {
    }

    public virtual DbSet<GanreShedBd> AuthorShedBds { get; set; }

    public virtual DbSet<BookShedBd> BookShedBds { get; set; }

    public virtual DbSet<CrossAuthorBookShedBd> CrossAuthorBookShedBds { get; set; }

    public virtual DbSet<GenreShedBd> GenreShedBds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=192.168.200.35;database=user02;user=user02;password=77053;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GanreShedBd>(entity =>
        {
            entity.ToTable("Author(ShedBD)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Experience).HasMaxLength(225);
            entity.Property(e => e.Fio)
                .HasMaxLength(225)
                .HasColumnName("FIO");
        });

        modelBuilder.Entity<BookShedBd>(entity =>
        {
            entity.ToTable("Book(ShedBD)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasMaxLength(225);
            entity.Property(e => e.IdGenre).HasColumnName("idGenre");
            entity.Property(e => e.Title).HasMaxLength(225);

            entity.HasOne(d => d.IdGenreNavigation).WithMany(p => p.BookShedBds)
                .HasForeignKey(d => d.IdGenre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book(ShedBD)_Genre(ShedBD)");
        });

        modelBuilder.Entity<CrossAuthorBookShedBd>(entity =>
        {
            entity.ToTable("CrossAuthorBook(ShedBD)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdAuthhor).HasColumnName("idAuthhor");
            entity.Property(e => e.IdBook).HasColumnName("idBook");

            entity.HasOne(d => d.IdAuthhorNavigation).WithMany(p => p.CrossAuthorBookShedBds)
                .HasForeignKey(d => d.IdAuthhor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CrossAuthorBook(ShedBD)_Author(ShedBD)");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.CrossAuthorBookShedBds)
                .HasForeignKey(d => d.IdBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CrossAuthorBook(ShedBD)_Book(ShedBD)");
        });

        modelBuilder.Entity<GenreShedBd>(entity =>
        {
            entity.ToTable("Genre(ShedBD)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(225);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
