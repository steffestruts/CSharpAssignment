using Business.Dtos;
using Business.Factories;
using Business.Models;

namespace Tests.Factories;

public class ContactFactory_Tests
{
    [Fact]
    public void Create_ShouldReturnContactRegistrationForm()
    {
        // Arrange
        // Act
        var result = ContactFactory.Create();
        // Assert
        Assert.NotNull(result);
        Assert.IsType<ContactRegistrationForm>(result);
    }
    [Fact]
    public void Create_ShouldReturnContact_WhenContactRegistrationFormIsProvided()
    {
        // Arrange
        var contactRegistrationForm = new ContactRegistrationForm()
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "test@domain.com"
        };

        // Act
        var result = ContactFactory.Create(contactRegistrationForm);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Contact>(result);
        Assert.Equal(contactRegistrationForm.FirstName, result.FirstName);
        Assert.Equal(contactRegistrationForm.LastName, result.LastName);
        Assert.Equal(contactRegistrationForm.Email, result.Email);
        Assert.Equal(contactRegistrationForm.PhoneNumber, result.PhoneNumber);
        Assert.Equal(contactRegistrationForm.Address, result.Address);
        Assert.Equal(contactRegistrationForm.PostalCode, result.PostalCode);
        Assert.Equal(contactRegistrationForm.City, result.City);
    }
}
