namespace IntroValueObject
{
    internal struct DiceStruct
    {
        public int Number { get; set; }

        public DiceStruct(int number)
        {
            if (number < 1 || number > 6) throw new ArgumentException("Ugyldig terningverdi: " + number);
            Number = number;
        }
    }
}
