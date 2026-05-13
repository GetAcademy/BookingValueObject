


using IntroValueObject;

var per = new Person
{
    Name = new PersonName("Per"),
    StreetName = new StreetName("Gata")
};

var pål = new Person
{
    Name = new PersonName("Pål"),
    StreetName = new StreetName("Veien")
};


//per.Name = pål.StreetName;