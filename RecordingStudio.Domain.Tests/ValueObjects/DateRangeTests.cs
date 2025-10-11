using Xunit;

namespace RecordingStudio.Domain.Tests.ValueObjects
{
    public class DateRangeTests
    {
        [Fact]
        public void Constructor_ShouldCreateDateRange_WhenStartIsBeforeEnd()
        {
            // Arrange
            var start = new DateTime(2025, 10, 20, 14, 0, 0);
            var end = new DateTime(2025, 10, 20, 16, 0, 0);

            // Act
            var dateRange = new DateRange(start, end);

            // Assert
            Assert.NotNull(dateRange);
            Assert.Equal(start, dateRange.Start);
            Assert.Equal(end, dateRange.End);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentException_WhenStartIsAfterEnd()
        {
            // Arrange
            var start = new DateTime(2025, 10, 20, 18, 0, 0);
            var end = new DateTime(2025, 10, 20, 16, 0, 0);

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new DateRange(start, end));

        }
        [Theory]
        [InlineData("2025-10-20 11:00", "2025-10-20 13:00", true, "Começa antes, termina durante")]
        [InlineData("2025-10-20 13:00", "2025-10-20 15:00", true, "Começa durante, termina depois")]
        [InlineData("2025-10-20 12:30", "2025-10-20 13:30", true, "Totalmente contido")]
        [InlineData("2025-10-20 11:00", "2025-10-20 15:00", true, "Contém o intervalo existente")]
        [InlineData("2025-10-20 12:00", "2025-10-20 14:00", true, "Intervalo idêntico")]

        [InlineData("2025-10-20 10:00", "2025-10-20 12:00", false, "Fronteira (termina quando o outro começa)")]
        [InlineData("2025-10-20 14:00", "2025-10-20 16:00", false, "Fronteira (começa quando o outro termina)")]
        [InlineData("2025-10-20 15:00", "2025-10-20 17:00", false, "Totalmente depois")]
        [InlineData("2025-10-20 09:00", "2025-10-20 11:00", false, "Totalmente antes")]
        public void Overlaps_ShouldReturnExpectedResult_ForGivenRanges(string newRangeStart, string newRangeEnd, bool expectedResult, string scenario)
        {
            var existingRange = new DateRange(
                new DateTime(2025, 10, 20, 12, 0, 0),
                new DateTime(2025, 10, 20, 14, 0, 0));

            var newRange = new DateRange(DateTime.Parse(newRangeStart), DateTime.Parse(newRangeEnd));

            var result = DateRange.Overlaps(existingRange, newRange);

            Assert.True(expectedResult == result, $"Falha no cenário: {scenario}");
        }
    }
}
