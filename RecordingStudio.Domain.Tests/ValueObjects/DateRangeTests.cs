using RecordingStudio.Domain;
using Xunit;

namespace RecordingStudio.Domain.Tests.ValueObjects
{
    public class DateRangeTests
    {
        [Fact]
        public void Construtor_DataInicioMaiorQueFim_DeveLancarExcecao()
        {
            var inicio = DateTime.Now.AddHours(2);
            var fim = DateTime.Now;

            Assert.Throws<ArgumentOutOfRangeException>(() => new DateRange(inicio, fim));
        }

        [Fact]
        public void Construtor_DatasValidas_DeveCriarComSucesso()
        {
            var inicio = DateTime.Now;
            var fim = inicio.AddHours(2);

            var dateRange = new DateRange(inicio, fim);

            Assert.Equal(inicio, dateRange.Start);
            Assert.Equal(fim, dateRange.End);
        }

        [Fact]
        public void Overlaps_PeriodosSobrepostos_DeveRetornarTrue()
        {
            var range1 = new DateRange(
                new DateTime(2024, 1, 1, 10, 0, 0),
                new DateTime(2024, 1, 1, 12, 0, 0)
            );
            
            var range2 = new DateRange(
                new DateTime(2024, 1, 1, 11, 0, 0),
                new DateTime(2024, 1, 1, 13, 0, 0)
            );

            var resultado = DateRange.Overlaps(range1, range2);

            Assert.True(resultado);
        }

        [Fact]
        public void Overlaps_PeriodosNaoSobrepostos_DeveRetornarFalse()
        {
            var range1 = new DateRange(
                new DateTime(2024, 1, 1, 10, 0, 0),
                new DateTime(2024, 1, 1, 11, 0, 0)
            );
            
            var range2 = new DateRange(
                new DateTime(2024, 1, 1, 12, 0, 0),
                new DateTime(2024, 1, 1, 13, 0, 0)
            );

            var resultado = DateRange.Overlaps(range1, range2);

            Assert.False(resultado);
        }
    }
}
