using System.Collections.Generic;

namespace DNVImatisAssignment.Entities
{
    public class Package
    {
        public Package()
        {
            Promotions = new List<Promotion>();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public List<Promotion> Promotions { get; set; }
    }
}