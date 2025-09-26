using System;
using System.Collections.Generic;

namespace Day1_Task.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public DateTime SaleDate { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
