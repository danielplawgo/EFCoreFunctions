using System;

namespace EFCoreFunctions
{
    public class ProductCreated
    {
        public ProductCreated(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; set; }
    }

    public class ProductUpdated
    {
        public ProductUpdated(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; set; }
    }
}