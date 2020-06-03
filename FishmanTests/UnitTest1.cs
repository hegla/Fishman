using Fishman.Controllers;
using Fishman.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace FishmanTests
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<FishmanContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-9L7KP7D\\SQLEXPRESS; Database=fishman; Trusted_Connection=True; MultipleActiveResultSets=true");

            var controller = new CountriesController(new FishmanContext(optionsBuilder.Options));

            var result = await controller.GetCountries();

            Assert.Contains(result.Value, g => g.Name.Equals("Ukraine"));
        }
    }
}
