﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------


namespace WriteReadProjectDemo
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class Entities : DbContext
{
    public Entities()
        : base("name=Entities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<edIzm> edIzm { get; set; }

    public virtual DbSet<manufacture> manufacture { get; set; }

    public virtual DbSet<Order> Order { get; set; }

    public virtual DbSet<OrderProduct> OrderProduct { get; set; }

    public virtual DbSet<Point> Point { get; set; }

    public virtual DbSet<Product> Product { get; set; }

    public virtual DbSet<ProductCategory> ProductCategory { get; set; }

    public virtual DbSet<Role> Role { get; set; }

    public virtual DbSet<statusChange> statusChange { get; set; }

    public virtual DbSet<supplier> supplier { get; set; }

    public virtual DbSet<User> User { get; set; }

}

}

