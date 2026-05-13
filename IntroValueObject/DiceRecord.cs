namespace IntroValueObject
{
    internal record class DiceRecord
    {
        public int Number { get; set; }

        public DiceRecord(int number)
        {
            if (number < 1 || number > 6) throw new ArgumentException("Ugyldig terningverdi: " + number);
            Number = number;
        }
    }
}
