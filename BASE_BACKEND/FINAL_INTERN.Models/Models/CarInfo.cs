﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FINAL_INTERN.Models.Models;

public partial class CarInfo
{
    public int Id { get; set; }

    public string Model { get; set; }

    public DateTime? Years { get; set; }

    public decimal? Price { get; set; }

    public string Transmission { get; set; }

    public string FuelType { get; set; }

    public int? StockQuantit { get; set; }

    public string Description { get; set; }

    public string Img { get; set; }

    public string Alt { get; set; }

    public bool? IsActive { get; set; }

    public int CategoriesOfCarId { get; set; }

    public virtual CategoriesOfCar CategoriesOfCar { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}