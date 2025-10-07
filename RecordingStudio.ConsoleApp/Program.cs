using RecordingStudio.Domain;
using System;

namespace RecordingStudio.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🎵 AGENDA DE ESTÚDIO DE GRAVAÇÃO 🎵");
            Console.WriteLine("=====================================\n");

            // 1. Criar uma sala de estúdio
            var sala = new StudioRoom(1, "Sala Principal");
            Console.WriteLine($"✅ Sala criada: {sala.Name} (ID: {sala.Id})");

            // 2. Criar músicos
            var guitarrista = new Musician(1, "Carlos Santos", "Carlos Guitar");
            var vocalista = new Musician(2, "Ana Silva", "Ana Voice");
            var baterista = new Musician(3, "Pedro Costa");
            
            Console.WriteLine($"✅ Músicos criados:");
            Console.WriteLine($"   - {guitarrista.FullName} ({guitarrista.StageName})");
            Console.WriteLine($"   - {vocalista.FullName} ({vocalista.StageName})");
            Console.WriteLine($"   - {baterista.FullName}");

            // 3. Atribuir carteira sindical para um músico
            guitarrista.AssignUnionCard("UC12345", DateTime.Now.AddYears(1));
            Console.WriteLine($"✅ Carteira sindical atribuída para {guitarrista.FullName}");

            // 4. Criar sessões
            var sessaoManha = new Session(1, sala, 
                new DateRange(DateTime.Today.AddHours(10), DateTime.Today.AddHours(12)));
            
            var sessaoTarde = new Session(2, sala,
                new DateRange(DateTime.Today.AddHours(14), DateTime.Today.AddHours(16)));

            Console.WriteLine($"✅ Sessões criadas:");
            Console.WriteLine($"   - Manhã: {sessaoManha.TimeRange}");
            Console.WriteLine($"   - Tarde: {sessaoTarde.TimeRange}");

            // 5. Adicionar participantes às sessões
            sessaoManha.AddParticipant(guitarrista, Instrument.Guitar, Role.Leader);
            sessaoManha.AddParticipant(vocalista, Instrument.Vocals, Role.Member);
            
            sessaoTarde.AddParticipant(baterista, Instrument.Drums, Role.Leader);
            sessaoTarde.AddParticipant(guitarrista, Instrument.Guitar, Role.Member);

            Console.WriteLine($"✅ Participantes adicionados às sessões");

            // 6. Agendar sessões na sala
            sala.Schedule(sessaoManha);
            sala.Schedule(sessaoTarde);
            Console.WriteLine($"✅ Sessões agendadas na sala {sala.Name}");

            // 7. Verificar se as sessões foram agendadas
            Console.WriteLine($"\n📅 SESSÕES AGENDADAS NA {sala.Name.ToUpper()}:");
            foreach (var sessao in sala.Sessions)
            {
                Console.WriteLine($"\n   Sessão {sessao.Id}: {sessao.TimeRange}");
                Console.WriteLine($"   Participantes:");
                foreach (var participante in sessao.Participants)
                {
                    var horarioChegada = participante.ArrivalTime.HasValue 
                        ? participante.ArrivalTime.Value.ToString("HH:mm") 
                        : "Não informado";
                    
                    Console.WriteLine($"     - {participante.Musician.FullName} " +
                                    $"({participante.Instrument}) " +
                                    $"- {participante.Role} " +
                                    $"[Chegada: {horarioChegada}]");
                }
            }

            // 8. Testar validações
            Console.WriteLine($"\n🧪 TESTANDO VALIDAÇÕES:");

            try
            {
                // Tentar criar sessão com horário inválido
                var sessaoInvalida = new Session(3, sala,
                    new DateRange(DateTime.Today.AddHours(18), DateTime.Today.AddHours(16)));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"   ❌ Validação de horário funcionou: {ex.Message}");
            }

            try
            {
                // Tentar adicionar o mesmo músico duas vezes
                sessaoManha.AddParticipant(guitarrista, Instrument.Guitar, Role.Guest);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"   ❌ Validação de duplicidade funcionou: {ex.Message}");
            }

            try
            {
                // Tentar criar músico sem nome
                var musicoInvalido = new Musician(4, "");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"   ❌ Validação de nome funcionou: {ex.Message}");
            }

            Console.WriteLine($"\n🎉 DEMONSTRAÇÃO CONCLUÍDA COM SUCESSO!");
            Console.WriteLine($"Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
