﻿using System;

namespace CentricExpress.Business.Domain
{
    public class OrderLine : IAggregate
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
    }
}
