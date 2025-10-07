namespace RecordingStudio.Domain
{
    public class UnionCard
    {
        public string Number { get; }
        public DateTime Expiration { get; }

        public UnionCard(string number, DateTime expiration)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("O número da carteira não pode estar vazio.", nameof(number));

            if (expiration <= DateTime.Now)
                throw new ArgumentOutOfRangeException(nameof(expiration), "A data de expiração deve ser futura.");

            Number = number.Trim();
            Expiration = expiration;
        }
    }
}