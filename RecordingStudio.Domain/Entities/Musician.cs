namespace RecordingStudio.Domain
{
    public class Musician
    {
        public int Id { get; }
        public string FullName { get; }
        public string? StageName { get; }
        public UnionCard? UnionCard { get; private set; }

        public Musician(int id, string fullName, string? stageName = null)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "O ID do músico deve ser um número positivo.");
                
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("O nome completo do músico é obrigatório.", nameof(fullName));

            Id = id;
            FullName = fullName.Trim();
            StageName = stageName?.Trim();
        }

        public void AssignUnionCard(string number, DateTime expiration)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("O número da carteira sindical não pode estar vazio.", nameof(number));
                
            UnionCard = new UnionCard(number, expiration);
        }
        
        public void RemoveUnionCard()
        {
            UnionCard = null;
        }
    }
}