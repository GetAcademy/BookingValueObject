namespace IntroValueObject
{
    internal class Person
    {
        public PersonName Name { get; set; }
        public StreetName StreetName { get; set; }
        public string StreetNo { get; set; }
        public string ZipCode { get; set; }
        public string Place { get; set; }
    }
}
