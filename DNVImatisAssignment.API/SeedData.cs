using DNVImatisAssignment.Entities;
using DNVImatisAssignment.Infrastructures;
using System.Collections.Generic;

namespace DNVImatisAssignment
{
    public class SeedData
    {
        public static void Init(ApplicationContext context)
        {
            InitCompaniesData(context);
            InitPackageData(context);
            InitPromotionData(context);
            context.SaveChanges();
        }

        private static void InitCompaniesData(ApplicationContext context)
        {
            var companies = new List<Company>
            {
                new Company
                {
                    Id = "1",
                    Name = "Normal Company"
                },
                new Company
                {
                    Id = "2",
                    Name = "IMT Company"
                },
                new Company
                {
                    Id = "3",
                    Name = "FWH Company"
                },
                new Company
                {
                    Id = "4",
                    Name = "DNV Company"
                }
            };
            context.AddRange(companies);
        }

        private static void InitPackageData(ApplicationContext context)
        {
            var packages = new List<Package>
            {
                new Package
                {
                    Id = "1",
                    Name = "Basic Package",
                    Description = "10 health check-up items",
                    Price = 99.99m
                },
                new Package
                {
                    Id = "2",
                    Name = "Standard Package",
                    Description = "15 health check-up items",
                    Price = 129.99m
                },
                new Package
                {
                    Id = "3",
                    Name = "Advanced Package",
                    Description = "20 health check-up items",
                    Price = 149.99m
                }
            };
            context.AddRange(packages);
        }

        private static void InitPromotionData(ApplicationContext context)
        {
            var promotions = new List<Promotion>
            {
                new Promotion
                {
                    Id = "1",
                    Name = "Get a 6 of 4 for Basic Package",
                    IdCompany = "2",
                    IdPackage = "1",
                    PackageActualNumber = 6,
                    PackageCaculateNumber = 4,
                    Type = (int)PromotionType.NumberPackage
                },
                new Promotion
                {
                    Id = "2",
                    Name = "On Advanced Package get the price drops to $139.99",
                    IdCompany = "3",
                    IdPackage = "3",
                    Type = (int)PromotionType.DropPrice,
                    PriceDropNumber = 139.99m
                },
                new Promotion
                {
                    Id="3",
                    Name = "Get a 10 of 5 for Standard Package",
                    IdCompany = "4",
                    IdPackage = "2",
                    Type =(int) PromotionType.NumberPackage,
                    PackageActualNumber = 10,
                    PackageCaculateNumber = 5
                }
            };
            context.AddRange(promotions);
        }
    }
}