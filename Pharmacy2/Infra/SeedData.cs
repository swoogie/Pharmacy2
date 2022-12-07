using Microsoft.EntityFrameworkCore;
using Pharmacy2.Models;

namespace Pharmacy2.Infra
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();

            if (!context.Drugs.Any())
            {
                Category medicine = new Category { Name = "Medicine", Slug = "medicine" };
                Category supplements = new Category { Name = "Supplements", Slug = "supplements" };
                Category vitamins = new Category { Name = "Vitamins", Slug = "vitamins"  };

                context.Drugs.AddRange(
                        new Drug
                        {
                            Name = "Ibuprom Express",
                            Slug = "ibuprofen",
                            Description = "Painkiller",
                            Price = 1.50M,
                            Category = medicine,
                            Image = "ibuprom.jpg"
                        },
                        new Drug
                        {
                            Name = "Mezym",
                            Slug = "mezym",
                            Description = "Digestive medicine",
                            Price = 2M,
                            Category = medicine,
                            Image = "mezym.png"
                        },
                        new Drug
                        {
                            Name = "Voltaren",
                            Slug = "diclofenac",
                            Description = "Anti inflammatory",
                            Price = 0.50M,
                            Category = medicine,
                            Image = "voltaren.jpg"
                        },
                        new Drug
                        {
                            Name = "Mollers",
                            Slug = "mollers",
                            Description = "Fish fat",
                            Price = 2.50M,
                            Category = vitamins,
                            Image = "mollers.png"
                        },
                        new Drug
                        {
                            Name = "Vitamin C",
                            Slug = "vitaminc",
                            Description = "Vitamin C",
                            Price = 5.99M,
                            Category = vitamins,
                            Image = "vitamincprolong.jpg"
                        },
                        new Drug
                        {
                            Name = "Vitamin B",
                            Slug = "vitaminb",
                            Description = "Vitamin B",
                            Price = 7.99M,
                            Category = vitamins,
                            Image = "bcomplex.jpg"
                        },
                        new Drug
                        {
                            Name = "Magnesium",
                            Slug = "magnesium",
                            Description = "Magnesium",
                            Price = 3.99M,
                            Category = vitamins,
                            Image = "magnesium.jpg"
                        },
                        new Drug
                        {
                            Name = "Imunital",
                            Slug = "imunital",
                            Description = "Imune system",
                            Price = 9.99M,
                            Category = supplements,
                            Image = "imunital.png"
                        },
                        new Drug
                        {
                            Name = "Liuberin",
                            Slug = "liuberin",
                            Description = "Eye supplement",
                            Price = 10.99M,
                            Category = supplements,
                            Image = "liuberin.jpg"
                        },
                        new Drug
                        {
                            Name = "Imunital",
                            Slug = "imunital",
                            Description = "Imune system",
                            Price = 9.99M,
                            Category = supplements,
                            Image = "imunital.png"
                        },
                        new Drug
                        {
                            Name = "Biocell",
                            Slug = "biocell",
                            Description = "Skin treatment",
                            Price = 11.99M,
                            Category = supplements,
                            Image = "biocell.png"
                        }
                );

                context.SaveChanges();
            }
        }
    }
}