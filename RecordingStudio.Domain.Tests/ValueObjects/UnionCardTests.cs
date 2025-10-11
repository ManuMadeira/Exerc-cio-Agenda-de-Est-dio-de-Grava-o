using RecordingStudio.Domain;
using Xunit;

public class UnionCardTests
{
    [Fact]
    public void Constructor_ShouldThrowArgumentException_WhenExpirationDateIsInThePast()
    {
        // Arrange
        var number = "12345";
        var expiredDate = DateTime.Now.AddDays(-1);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new UnionCard(number, expiredDate));
    }

    [Fact]
    public void Constructor_ShouldCreateUnionCard_WhenExpirationDateIsInTheFuture()
    {
        // Arrange
        var number = "54321";
        var futureDate = DateTime.Now.AddDays(1);

        // Act
        var unionCard = new UnionCard(number, futureDate);

        // Assert
        Assert.NotNull(unionCard);
        Assert.Equal(number, unionCard.Number);
    }
}