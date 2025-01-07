using Business.Helpers;

namespace Tests.Helpers;

public class IdGenerator_Tests
{
    [Fact]
    public void GenerateId_ShouldReturnsGuidAsString()
    {
        // Act
        var result = IdGenerator.Generate();

        // Assert
        Assert.NotNull(result);
        Assert.True(Guid.TryParse(result, out _));
    }
}
