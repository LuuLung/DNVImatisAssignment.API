using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DNVImatisAssignment.API.Infrastructures.RequestsModel
{
    public class PriceCaculationRequest
    {
        [Required]
        public string CompanyId { get; set; }

        [Required]
        public List<PackageRequest> Packages { get; set; }
    }

    public class PackageRequest
    {
        [Required]
        public string PackageId { get; set; }

        public int NumberOfPackage { get; set; }
    }
}
