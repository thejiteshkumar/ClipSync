using ClipSync.UI.Views;

namespace ClipSync.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ClipsListPage), typeof(ClipsListPage));
        }
    }
}