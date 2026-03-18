namespace PokemonBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, and welcome every one in our first Pokemon Battle. Good luck!");
            Squirtle squirtle = new Squirtle("Jeremy");
            Charmander charmander = new Charmander("Bitey");

            PokemonBattle battle = new PokemonBattle(squirtle, charmander);
            battle.Start();
        }
    }
}
