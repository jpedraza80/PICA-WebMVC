using Moq;
using Pica.Taller.Core.Entities;
using Pica.Taller.Core.Interfaces;
using Pica.Taller.Core.Services;
using System.Threading.Tasks;
using Xunit;

namespace CoreTest
{
    public class ContactServiceTest
    {
        [Fact]
        public async Task GetContactSuccess()
        {
            // Arrange
            var mock = new Mock<IContactRepository>();
            mock.Setup(p => p.Get("test@mail.com")).Returns(Task.FromResult(new ContactInfo
            {
                Email = "test@mail.com",
                Address = "Address 123",
                FullName = "Test User"
            }));

            ContactService service = new ContactService(mock.Object);

            // Act
            ContactInfo result = await service.Get("test@mail.com");

            // Assert
            Assert.Equal("test@mail.com", result.Email);
        }

        [Fact]
        public async Task UpdateContactNotExists()
        {
            // Arrange
            ContactInfo testContact = new ContactInfo
            {
                Email = "test@mail.com",
                Address = "Address 123",
                FullName = "Test User"
            };

            var mock = new Mock<IContactRepository>();
            mock.Setup(p => p.Get("test@mail.com")).Returns(Task.FromResult<ContactInfo>(null));
            mock.Setup(p => p.Add(testContact)).Returns(Task.FromResult<ContactInfo>(null));

            ContactService service = new ContactService(mock.Object);

            // Act
            ContactInfo result = await service.Update(testContact);

            // Assert
            Assert.Equal("test@mail.com", result.Email);
            Assert.Equal("Address 123", result.Address);
            Assert.Equal("Test User", result.FullName);
        }

        [Fact]
        public async Task UpdateContactAlreadyExists()
        {
            // Arrange
            ContactInfo testContact = new ContactInfo
            {
                Email = "test@mail.com",
                Address = "Address 123",
                FullName = "Test User"
            };

            var mock = new Mock<IContactRepository>();
            mock.Setup(p => p.Get("test@mail.com")).Returns(Task.FromResult(new ContactInfo
            {
                Email = "test@mail.com",
                Address = "Address 123 OLD",
                FullName = "Test User OLD"
            }));
            mock.Setup(p => p.Add(testContact)).Returns(Task.FromResult(testContact));

            ContactService service = new ContactService(mock.Object);

            // Act
            ContactInfo result = await service.Update(testContact);

            // Assert
            Assert.Equal("test@mail.com", result.Email);
            Assert.Equal("Address 123", result.Address);
            Assert.Equal("Test User", result.FullName);
        }
    }
}