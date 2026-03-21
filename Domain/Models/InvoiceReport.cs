using System.Collections.Generic;

namespace Domain.Models;

public class InvoiceReport
{
    public string CustomerName { get; set; }
    public List<Item> Items { get; set; }
    public decimal Total { get; set; }
}