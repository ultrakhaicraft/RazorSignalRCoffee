using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject;

public partial class Coffee
{
    public int Id { get; set; }

    
	public string Name { get; set; } = null!;

    
	public string? Description { get; set; }

    
	public decimal UnitPrice { get; set; }

    
	public int StockQuantity { get; set; }
}
