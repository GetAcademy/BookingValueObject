namespace IntroValueObject
{
    internal class PersonName
    {
        public string Value { get; }

        public PersonName(string name)
        {
            if (name.Length > 200)
            {
                throw new ArgumentException("For langt navn");
            }
            Value = name;
        }
    }
}
