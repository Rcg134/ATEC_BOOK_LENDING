using System;
using System.Collections.Generic;
using ATEC_BOOK_LENDING.Model;
using Microsoft.EntityFrameworkCore;

namespace ATEC_BOOK_LENDING.Context;

public partial class BookContext : DbContext
{
    public BookContext()
    {
    }

    public BookContext(DbContextOptions<BookContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=RUSSELVIEMWAKIN\\AKEMSSQLSERVER;Database=Book;User Id=sa;Password=p@ssw0rd;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");

            entity.Property(e => e.BookId).HasColumnName("Book_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_Date");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable("Transaction");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BokkId).HasColumnName("Bokk_id");
            entity.Property(e => e.BorrowedDate)
                .HasColumnType("datetime")
                .HasColumnName("Borrowed_Date");
            entity.Property(e => e.IcountBorrowedItems).HasColumnName("Icount_Borrowed_items");
            entity.Property(e => e.IsReturn).HasColumnName("isReturn");
            entity.Property(e => e.ReturnDate)
                .HasColumnType("datetime")
                .HasColumnName("Return_Date");
            entity.Property(e => e.UserId).HasColumnName("User_id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("User_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_Date");
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Surname).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
