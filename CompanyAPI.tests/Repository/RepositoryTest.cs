using CompanyAPI.Data;
using CompanyAPI.Models;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.tests.Repository
{
    public class RepositoryTest
    {
        private readonly AppDbContext _contextMock;

        public RepositoryTest()
        {
            var mockOptions = new DbContextOptionsBuilder<AppDbContext>().Options;

            //_contextMock = A.Fake<AppDbContext>(x => x.WithArgumentsForConstructor(new object[] { mockOptions }));
            _contextMock = A.Fake<AppDbContext>(x => x.WithArgumentsForConstructor(() => new AppDbContext(new DbContextOptions<AppDbContext>())));


        }


        [Fact]
        public async Task GetCompanies_returnOk()
        {
               // Arrange
            var companyRepo = new CompanyRepo(_contextMock);
            var companies = new List<Company>
            {
                new Company { Id = 1, CompanyName = "Company1" },
                new Company { Id = 2, CompanyName = "Company2" }
            };
            A.CallTo(() => _contextMock.Companies.ToListAsync(CancellationToken.None)).Returns(companies);
            // Act
            var result = await companyRepo.GetAllCompanies();
            // Assert
            Assert.Equal(2, result.Count());
        }


    }
}
