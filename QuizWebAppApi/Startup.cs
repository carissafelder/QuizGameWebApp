using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuizWebAppApi.Startup))]
namespace QuizWebAppApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
