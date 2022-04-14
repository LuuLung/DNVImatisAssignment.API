namespace DNVImatisAssignment.Entities
{
    public class Promotion
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string IdCompany { get; set; }

        public string IdPackage { get; set; }

        /// <summary>
        /// NumberPackage:0, DropPrice: 1
        /// </summary>
        public int Type { get; set; }

        public int PackageActualNumber { get; set; }

        public int PackageCaculateNumber { get; set; }

        public decimal PriceDropNumber { get; set; }
    }
}