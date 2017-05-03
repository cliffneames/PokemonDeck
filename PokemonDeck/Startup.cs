using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PokemonDeck.Startup))]
namespace PokemonDeck
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
