using RecordingStudio.Domain;
using Xunit;

namespace RecordingStudio.Domain.Tests.Entities
{
    public class MusicianTests
    {
        [Fact]
        public void Construtor_NomeVazio_DeveLancarExcecao()
        {
            Assert.Throws<ArgumentException>(() => new Musician(1, string.Empty));
        }

        [Fact]
        public void Construtor_DadosValidos_DeveCriarComSucesso()
        {
            var musician = new Musician(1, "João Silva", "John Guitar");

            Assert.Equal("João Silva", musician.FullName);
            Assert.Equal("John Guitar", musician.StageName);
            Assert.Null(musician.UnionCard);
        }

        [Fact]
        public void AssignUnionCard_DadosValidos_DeveAtribuirCarteira()
        {
            var musician = new Musician(1, "Maria Santos");
            var number = "12345";
            var expiration = DateTime.Now.AddYears(1);

            musician.AssignUnionCard(number, expiration);

            Assert.NotNull(musician.UnionCard);
            Assert.Equal(number, musician.UnionCard.Number);
        }
    }
}
