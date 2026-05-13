using System.Runtime.InteropServices.JavaScript;

namespace IntroValueObject
{
    internal record class DiceClass(int number)
    {
        public void Show()
        {
            Console.WriteLine(number);
        }
    }
}
