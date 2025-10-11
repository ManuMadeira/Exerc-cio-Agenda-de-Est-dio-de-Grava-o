using RecordingStudio.Domain;
using Xunit;

public class StudioRoomTests
{
    [Fact]
    public void Schedule_ShouldThrowInvalidOperationException_WhenSessionOverlaps()
    {
        // Arrange
        var room = new StudioRoom(1,"Sala A");
        var existingSessionRange = new DateRange(
            new DateTime(2025, 11, 15, 10, 0, 0),
            new DateTime(2025, 11, 15, 12, 0, 0));
        var existingSession = new Session(2,room, existingSessionRange);

        existingSession.AddParticipant(new Musician(3,"Músico A"), Instrument.Guitar, Role.Member);

        room.Schedule(existingSession);

        var overlappingRange = new DateRange(
            new DateTime(2025, 11, 15, 11, 0, 0),
            new DateTime(2025, 11, 15, 13, 0, 0));
        var newSession = new Session(4,room, overlappingRange);
        newSession.AddParticipant(new Musician(5,"Músico B"), Instrument.Drums, Role.Member);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => room.Schedule(newSession));
    }
}
