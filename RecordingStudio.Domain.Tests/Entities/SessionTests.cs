using RecordingStudio.Domain;
using Xunit;

public class SessionTests
{
    [Fact]
    public void AddParticipant_ShouldThrowInvalidOperationException_WhenAddingSameMusicianTwice()
    {
        // Arrange
        var room = new StudioRoom(1, "Sala B");
        var timeRange = new DateRange(DateTime.Now, DateTime.Now.AddHours(2));
        var session = new Session(2, room, timeRange);
        var musician = new Musician(3, "John Doe");

        session.AddParticipant(musician, Instrument.Vocals, Role.Leader);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            session.AddParticipant(musician, Instrument.Guitar, Role.Member);
        });
    }
    [Fact]
    public void EnsureHasAtLeastOneParticipant_ShouldThrowInvalidOperationException_WhenNoParticipants()
    {
        // Arrange
        var room = new StudioRoom(4,"Sala C");
        var timeRange = new DateRange(DateTime.Now, DateTime.Now.AddHours(2));
        var session = new Session(5,room, timeRange);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => session.EnsureHasAtLeastOneParticipant());
    }

    [Fact]
    public void StudioRoom_Schedule_SessionWithoutParticipants_ThrowsException()
    {
        // Arrange
        var room = new StudioRoom(6, "Sala D");
        var timeRange = new DateRange(DateTime.Now, DateTime.Now.AddHours(2));
        var session = new Session(7, room, timeRange);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => room.Schedule(session));
    }
}